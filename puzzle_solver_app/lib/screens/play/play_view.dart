import 'package:flutter/material.dart';
import 'package:momentum/momentum.dart';
import 'package:puzzle_solver_app/home/home_controller.dart';
import 'package:puzzle_solver_app/puzzles/sudoku/sudoku.dart';
import 'package:puzzle_solver_app/puzzles/sudoku/sudoku_controller.dart';
import 'package:puzzle_solver_app/puzzles/sudoku/sudoku_view.dart';
import 'package:puzzle_solver_app/screens/play/play_controller.dart';
import 'package:puzzle_solver_app/utils/puzzle_enum_extension.dart';
import 'package:puzzle_solver_app/widgets/button.dart';

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

        return Scaffold(
          appBar: AppBar(
            title: Text("Playing ${puzzle.toPuzzleString()}"),
          ),
          body: Align(
            alignment: Alignment.center,
            child: FutureBuilder(
              future: sudokuController.allPuzzles(),
              builder: (context, snapshot) {
                if (snapshot.connectionState == ConnectionState.waiting) {
                  return const Center(
                    child: CircularProgressIndicator(),
                  );
                }

                List<String> puzzles = snapshot.data as List<String>;

                return Wrap(
                  children: [
                    for (int i = 0; i < puzzles.length; i++) ...[
                      CustomButton(
                        label: "Puzzle ${i + 1}",
                        onPressed: () {
                          Momentum.controller<PlayController>(context).navigate(
                            context,
                            view: SudokuView(
                              id: puzzles[i],
                              puzzle: puzzle,
                            ),
                          );
                        },
                      ),
                    ],
                  ],
                );
              },
            ),
          ),
        );
      },
    );
  }
}
