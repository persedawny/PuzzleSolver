import 'package:momentum/momentum.dart';
import 'package:puzzle_solver_app/puzzles/sudoku/sudoku.dart';
import 'package:puzzle_solver_app/puzzles/sudoku/sudoku_controller.dart';
import 'package:puzzle_solver_app/puzzles/sudoku/sudoku_field.dart';

class SudokuModel extends MomentumModel<SudokuController> {
  const SudokuModel(
    SudokuController controller, {
    required this.sudoku,
    this.selected,
    this.isSolving = false,
    this.isLoaded = false,
  }) : super(controller);

  final Sudoku sudoku;
  final SudokuField? selected;
  final bool isSolving;
  final bool isLoaded;

  @override
  void update(
      {Sudoku? sudoku,
      SudokuField? selected,
      bool? isSolving,
      bool? isLoaded}) {
    SudokuModel(
      controller,
      sudoku: sudoku ?? this.sudoku,
      selected: selected ?? this.selected,
      isSolving: isSolving ?? this.isSolving,
      isLoaded: isLoaded ?? this.isLoaded,
    ).updateMomentum();
  }
}
