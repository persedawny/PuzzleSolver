import 'dart:math';

import 'package:momentum/momentum.dart';
import 'package:puzzle_solver_app/puzzles/sudoku/sudoku_field.dart';
import 'package:puzzle_solver_app/puzzles/sudoku/sudoku_model.dart';

class SudokuController extends MomentumController<SudokuModel> {
  @override
  SudokuModel init() {
    return SudokuModel(this, fields: const []);
  }

  loadPuzzle() {
    if (model.fields.isEmpty) {
      List<SudokuField> fields = [];

      for (int i = 0; i < 81; i++) {
        Random rnd = Random();
        bool r = rnd.nextBool();
        SudokuField field = SudokuField(index: i, value: r ? null : 1);
        fields.add(field);
      }

      model.update(fields: fields);
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
    List<SudokuField> fields = model.fields;

    while (!hintFilledIn) {
      int index = rnd.nextInt(model.fields.length);
      SudokuField field = fields[index];
      if (field.value == null) {
        field.value = rnd.nextInt(9) + 1;
        hintFilledIn = true;
      }
    }

    model.update(fields: fields);

    return;
  }

  bool checkPuzzleAndGetResult() {
    bool isSolved = true;

    return isSolved;
  }

  clearPuzzle() {
    model.update(fields: []);
  }

  bool isFilledIn() {
    for (var field in model.fields) {
      if (field.value != null) {
        continue;
      } else {
        return false;
      }
    }
    return true;
  }
}
