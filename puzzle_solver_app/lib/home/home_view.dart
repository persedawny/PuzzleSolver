import 'package:flutter/material.dart';
import 'package:momentum/momentum.dart';
import 'package:puzzle_solver_app/enums/puzzle_enum.dart';
import 'package:puzzle_solver_app/home/home_controller.dart';
import 'package:puzzle_solver_app/home/home_model.dart';
import 'package:puzzle_solver_app/screens/play/play_view.dart';
import 'package:puzzle_solver_app/screens/solve/solve_view.dart';
import 'package:puzzle_solver_app/widgets/button.dart';

class HomeView extends StatelessWidget {
  const HomeView({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return MomentumBuilder(
      controllers: const [HomeController],
      builder: (context, snapshot) {
        var home = snapshot<HomeModel>();

        return Scaffold(
          appBar: AppBar(
            title: const Text("Puzzle Solver"),
          ),
          body: Center(
            child: Column(
              mainAxisAlignment: MainAxisAlignment.center,
              children: [
                DropdownButton(
                  onChanged: (puzzle) {
                    home.update(puzzle: puzzle as Puzzle);
                  },
                  value: home.puzzle,
                  items: const [
                    DropdownMenuItem(
                      value: Puzzle.sudoku,
                      child: Text('Sudoku'),
                    ),
                    DropdownMenuItem(
                      value: Puzzle.other,
                      child: Text('Other'),
                    ),
                  ],
                ),
                if (home.puzzle != Puzzle.other)
                  Column(
                    children: [
                      CustomButton(
                        label: "Play",
                        onPressed: () =>
                            Momentum.controller<HomeController>(context)
                                .navigate(
                          context,
                          view: const PlayView(),
                        ),
                      ),
                      CustomButton(
                        label: "Solve",
                        onPressed: () =>
                            Momentum.controller<HomeController>(context)
                                .navigate(
                          context,
                          view: const SolveView(),
                        ),
                      ),
                    ],
                  ),
                if (home.puzzle == Puzzle.other)
                  const Text(
                      "Want to do any puzzles that are not implemented yet! Come help us :)"),
              ],
            ),
          ),
        );
      },
    );
  }
}
