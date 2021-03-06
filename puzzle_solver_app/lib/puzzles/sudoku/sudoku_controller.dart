// ignore: unused_import
import 'dart:math';

import 'package:flutter/foundation.dart';
import 'package:momentum/momentum.dart';
import 'package:puzzle_solver_app/constants/constants.dart';
import 'package:puzzle_solver_app/puzzles/sudoku/sudoku.dart';
import 'package:puzzle_solver_app/puzzles/sudoku/sudoku_field.dart';
import 'package:puzzle_solver_app/puzzles/sudoku/sudoku_model.dart';
import 'package:puzzle_solver_app/puzzles/sudoku/sudoku_repository.dart';
import 'package:puzzle_solver_app/services/http_service.dart';

class SudokuController extends MomentumController<SudokuModel> {
  SudokuRepository sudokuRepository = SudokuRepository(
    HttpService(),
  );

  @override
  SudokuModel init() {
    return SudokuModel(
      this,
      sudoku: Sudoku(),
    );
  }

  int minimalFields = Constants.requiredFieldToSolve;
  int amountOfHintsGiven = 0;
  List<int> previousHint = [];

  Future<List<String>> allPuzzles() async {
    return await sudokuRepository.getAllPuzzles();
  }

  loadPuzzle(String puzzleId) async {
    if (Sudoku.usermade) {
      Sudoku sudoku = Sudoku();
      for (int i = 0; i < Constants.amountOfSudokuFields; i++) {
        SudokuField field = SudokuField(index: i, value: null);
        sudoku.fields.add(field);
      }
      model.update(sudoku: sudoku);
    } else {
      Sudoku sudoku = await sudokuRepository.getPuzzleById(puzzleId);
      model.update(sudoku: sudoku);
    }
    model.update(isLoaded: true);
  }

  selectField(SudokuField field) {
    model.update(selected: field);
  }

  setValue(int? val) {
    if (model.selected != null) {
      SudokuField field = model.selected!;
      field.value = val;

      if (val == null) {
        field.potentials = [1, 2, 3, 4, 5, 6, 7, 8, 9];
      } else {
        field.potentials = [];
      }

      model.update(selected: field);
    }
  }

  int _fieldsFilledIn() {
    int count = 0;
    for (SudokuField field in model.sudoku.fields) {
      if (field.value != null) {
        count++;
      }
    }
    return count;
  }

  bool minimalFieldsFilledIn() {
    int count = 0;
    for (SudokuField field in model.sudoku.fields) {
      if (field.value != null) {
        count++;
      }
    }
    return count >= minimalFields;
  }

  int fieldToFillMinimal() {
    return minimalFields - _fieldsFilledIn();
  }

  void setSolvingStatus(bool value) {
    model.update(isSolving: value);
  }

  bool getSolvingStatus() {
    return model.isSolving;
  }

  Future<void> getHint() async {
    if (amountOfHintsGiven < Constants.amountOfHints) {
      List<int> potentials = await sudokuRepository.getHint(model.sudoku);

      SudokuField field =
          model.sudoku.fields.firstWhere((element) => element.value == null);

      field.potentials = potentials;

      if (potentials.isNotEmpty && !listEquals(potentials, previousHint)) {
        amountOfHintsGiven++;
      }

      previousHint = potentials;

      model.update(selected: field);
    }
  }

  Future<bool> checkPuzzleAndGetResult() async {
    try {
      await sudokuRepository.solvePuzzle(model.sudoku);
    } catch (e) {
      debugPrint(e.toString());
      return false;
    }

    model.update(sudoku: model.sudoku);

    if (!isFilledIn()) {
      return false;
    }

    return true;
  }

  clearPuzzle() {
    model.update(sudoku: Sudoku());
  }

  List<SudokuField> copyFields() {
    List<SudokuField> fields = [];
    for (SudokuField field in model.sudoku.fields) {
      SudokuField newField = SudokuField();
      newField.index = field.index;
      newField.value = field.value;
      fields.add(newField);
    }
    return fields;
  }

  insertPuzzleInDB(Sudoku puzzle) {
    sudokuRepository.savePuzzle(puzzle);
  }

  bool isFilledIn() {
    for (var field in model.sudoku.fields) {
      if (field.value != null) {
        continue;
      } else {
        return false;
      }
    }
    return true;
  }

  List<int>? getPotentials() {
    return model.selected?.potentials;
  }
}
