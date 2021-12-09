import 'package:momentum/momentum.dart';
import 'package:puzzle_solver_app/puzzles/sudoku/sudoku_controller.dart';
import 'package:puzzle_solver_app/puzzles/sudoku/sudoku_field.dart';

class SudokuModel extends MomentumModel<SudokuController> {
  const SudokuModel(
    SudokuController controller, {
    this.fields = const <SudokuField>[],
    this.selected,
  }) : super(controller);

  final List<SudokuField> fields;
  final SudokuField? selected;

  @override
  void update({List<SudokuField>? fields, SudokuField? selected}) {
    SudokuModel(
      controller,
      fields: fields ?? this.fields,
      selected: selected ?? this.selected,
    ).updateMomentum();
  }
}
