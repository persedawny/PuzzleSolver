import 'package:flutter/material.dart';
import 'package:momentum/momentum.dart';
import 'package:puzzle_solver_app/home/home_controller.dart';
import 'package:puzzle_solver_app/puzzles/sudoku/sudoku.dart';
import 'package:puzzle_solver_app/puzzles/sudoku/sudoku_view.dart';
import 'package:puzzle_solver_app/screens/solve/solve_controller.dart';

class SolveView extends StatelessWidget {
  const SolveView({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return MomentumBuilder(
      controllers: const [SolveController],
      builder: (context, snapshot) {
        var puzzle =
            Momentum.controller<HomeController>(context).currentPuzzle();
        Sudoku.usermade = true;

        return SudokuView(
          puzzle: puzzle,
          id: "new",
        );
      },
    );
  }
}
