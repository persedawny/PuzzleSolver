import 'package:momentum/momentum.dart';
import 'package:puzzle_solver_app/puzzles/sudoku/sudoku.dart';
import 'package:puzzle_solver_app/puzzles/sudoku/sudoku_controller.dart';
import 'package:puzzle_solver_app/puzzles/sudoku/sudoku_field.dart';

class SudokuModel extends MomentumModel<SudokuController> {
  const SudokuModel(
    SudokuController controller, {
    required this.sudoku,
    this.selected,
  }) : super(controller);

  final Sudoku sudoku;
  final SudokuField? selected;

  @override
  void update({Sudoku? sudoku, SudokuField? selected}) {
    SudokuModel(
      controller,
      sudoku: sudoku ?? this.sudoku,
      selected: selected ?? this.selected,
    ).updateMomentum();
  }
}
