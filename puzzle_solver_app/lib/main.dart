import 'package:flutter/material.dart';
import 'package:momentum/momentum.dart';
import 'package:puzzle_solver_app/home/home_controller.dart';
import 'package:puzzle_solver_app/home/home_view.dart';
import 'package:puzzle_solver_app/puzzles/sudoku/sudoku_controller.dart';
import 'package:puzzle_solver_app/screens/play/play_controller.dart';
import 'package:puzzle_solver_app/screens/solve/solve_controller.dart';

void main() {
  runApp(
    Momentum(
      controllers: [
        HomeController(),
        PlayController(),
        SolveController(),
        SudokuController(),
      ],
      child: const App(),
    ),
  );
}

class App extends StatelessWidget {
  const App({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Puzzle Solver',
      theme: ThemeData(primarySwatch: Colors.blue),
      home: const HomeView(),
    );
  }
}
