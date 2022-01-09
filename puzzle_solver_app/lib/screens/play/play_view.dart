import 'package:flutter/material.dart';
import 'package:momentum/momentum.dart';
import 'package:puzzle_solver_app/home/home_controller.dart';
import 'package:puzzle_solver_app/puzzles/sudoku/sudoku.dart';
import 'package:puzzle_solver_app/puzzles/sudoku/sudoku_controller.dart';
import 'package:puzzle_solver_app/puzzles/sudoku/sudoku_view.dart';
import 'package:puzzle_solver_app/screens/play/play_controller.dart';
import 'package:puzzle_solver_app/utils/puzzle_enum_extension.dart';

class PlayView extends StatelessWidget {
  const PlayView({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return MomentumBuilder(
      controllers: const [PlayController],
      builder: (context, snapshot) {
        var puzzle =
            Momentum.controller<HomeController>(context).currentPuzzle();
        Sudoku.usermade = false;
        var sudokuController = Momentum.controller<SudokuController>(context);
        sudokuController.loadPuzzle();
        return Scaffold(
          appBar: AppBar(
            title: Text("Playing ${puzzle.toPuzzleString()}"),
          ),
          body: const SudokuView(),
        );
      },
    );
  }
}
