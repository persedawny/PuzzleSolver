import 'dart:math';

import 'package:momentum/momentum.dart';
import 'package:puzzle_solver_app/puzzles/sudoku/sudoku_field.dart';
import 'package:puzzle_solver_app/puzzles/sudoku/sudoku_model.dart';

class SudokuController extends MomentumController<SudokuModel> {
  @override
  SudokuModel init() {
    List<SudokuField> fields = [];

    for (int i = 0; i < 81; i++) {
      Random rnd = Random();
      bool r = rnd.nextBool();
      SudokuField field = SudokuField(index: i, value: r ? null : 1);
      fields.add(field);
    }
    return SudokuModel(this, fields: fields);
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
}
