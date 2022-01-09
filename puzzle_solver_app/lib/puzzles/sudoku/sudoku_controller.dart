import 'dart:math';

import 'package:momentum/momentum.dart';
import 'package:puzzle_solver_app/puzzles/sudoku/sudoku.dart';
import 'package:puzzle_solver_app/puzzles/sudoku/sudoku_field.dart';
import 'package:puzzle_solver_app/puzzles/sudoku/sudoku_model.dart';
import 'package:puzzle_solver_app/puzzles/sudoku/sudoku_service.dart';

class SudokuController extends MomentumController<SudokuModel> {
  SudokuService sudokuService =
      SudokuService(baseUrl: 'http://localhost:5000/');
  // SudokuService(baseUrl: 'http://10.0.2.2:5001/');

  @override
  SudokuModel init() {
    return SudokuModel(
      this,
      sudoku: Sudoku(),
    );
  }

  loadPuzzle() async {
    if (model.sudoku.fields.isEmpty) {
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
  }

  selectField(SudokuField field) {
    model.update(selected: field);
  }

  setValue(int val) {
    if (model.selected != null) {
      SudokuField field = model.selected!;
      field.value = val;
      model.update(selected: field);
    }
  }

  void getHint() {
    Random rnd = Random();

    bool hintFilledIn = false;
    Sudoku sudoku = model.sudoku;

    while (!hintFilledIn) {
      int index = rnd.nextInt(model.sudoku.fields.length);
      SudokuField field = sudoku.fields[index];
      if (field.value == null) {
        field.value = rnd.nextInt(9) + 1;
        hintFilledIn = true;
      }
    }

    model.update(sudoku: sudoku);

    return;
  }

  Future<bool> checkPuzzleAndGetResult() async {
    await sudokuService.solvePuzzle(model.sudoku);

    return false;
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
}
