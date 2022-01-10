import 'dart:math';

import 'package:momentum/momentum.dart';
import 'package:puzzle_solver_app/puzzles/sudoku/sudoku.dart';
import 'package:puzzle_solver_app/puzzles/sudoku/sudoku_field.dart';
import 'package:puzzle_solver_app/puzzles/sudoku/sudoku_model.dart';
import 'package:puzzle_solver_app/puzzles/sudoku/sudoku_service.dart';

class SudokuController extends MomentumController<SudokuModel> {
  SudokuService sudokuService =
      SudokuService(baseUrl: 'http://localhost:5000/');

  static const int _minialFields = 17;

  @override
  SudokuModel init() {
    return SudokuModel(
      this,
      sudoku: Sudoku(),
    );
  }

  loadPuzzle() async {
    if (Sudoku.usermade) {
      Sudoku sudoku = Sudoku();
      for (int i = 0; i < 81; i++) {
        SudokuField field = SudokuField(index: i, value: null);
        sudoku.fields.add(field);
      }
      model.update(sudoku: sudoku);
    } else {
      Sudoku sudoku = await sudokuService.getPuzzle(30);
      model.update(sudoku: sudoku);
    }
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
    return count >= _minialFields;
  }

  int fieldToFillMinimal() {
    return _minialFields - _fieldsFilledIn();
  }

  void setSolvingStatus(bool value) {
    model.update(isSolving: value);
  }

  bool getSolvingStatus() {
    return model.isSolving;
  }

  void getHint() {
    Random rnd = Random();

    Sudoku sudoku = model.sudoku;

    bool hintFilledIn = false;

    late SudokuField field;
    while (!hintFilledIn) {
      int index = rnd.nextInt(model.sudoku.fields.length);
      field = sudoku.fields[index];

      if (field.value == null) {
        field.potentials.remove(field.potentials.first);
        hintFilledIn = true;
      }
    }

    model.update(sudoku: sudoku, selected: field);

    return;
  }

  Future<bool> checkPuzzleAndGetResult() async {
    await sudokuService.solvePuzzle(model.sudoku);

    model.update(sudoku: model.sudoku);

    if (!isFilledIn()) {
      return false;
    }

    return true;
  }

  clearPuzzle() {
    model.update(sudoku: Sudoku());
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
