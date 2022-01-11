import 'package:flutter/material.dart';
import 'package:momentum/momentum.dart';
import 'package:puzzle_solver_app/enums/puzzle_enum.dart';
import 'package:puzzle_solver_app/home/home_model.dart';

class HomeController extends MomentumController<HomeModel> {
  @override
  HomeModel init() {
    return HomeModel(
      this,
      puzzle: PuzzleType.sudoku,
    );
  }

  void update(PuzzleType p) {
    model.update(puzzle: p);
  }

  PuzzleType currentPuzzle() {
    return model.puzzle;
  }

  navigate(BuildContext context, {required Widget view}) {
    Navigator.of(context)
        .push(MaterialPageRoute(builder: (BuildContext context) => view));
  }
}
