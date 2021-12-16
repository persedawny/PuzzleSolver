import 'package:flutter/material.dart';
import 'package:momentum/momentum.dart';
import 'package:puzzle_solver_app/puzzles/sudoku/sudoku.dart';
import 'package:puzzle_solver_app/puzzles/sudoku/sudoku_controller.dart';
import 'package:puzzle_solver_app/puzzles/sudoku/sudoku_field.dart';
import 'package:puzzle_solver_app/widgets/button.dart';

class SudokuView extends StatelessWidget {
  const SudokuView({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return MomentumBuilder(
      controllers: const [SudokuController],
      builder: (context, snapshot) {
        var con = Momentum.controller<SudokuController>(context);
        con.loadPuzzle();

        return Column(
          mainAxisAlignment: MainAxisAlignment.center,
          children: [
            Center(
              child: con.model.sudoku.fields.isEmpty
                  ? const CircularProgressIndicator()
                  : SizedBox(
                      height: MediaQuery.of(context).size.height * 0.4,
                      width: MediaQuery.of(context).size.height * 0.4,
                      child: GridView(
                        gridDelegate:
                            const SliverGridDelegateWithFixedCrossAxisCount(
                          crossAxisCount: 9,
                        ),
                        children: con.model.sudoku.fields
                            .map(
                              (e) => sudokuField(e, con),
                            )
                            .toList(),
                      ),
                    ),
            ),
            const SizedBox(
              height: 20,
            ),
            SizedBox(
              width: MediaQuery.of(context).size.height * 0.4,
              child: Center(
                child: Wrap(
                  children: [
                    for (int i = 1; i <= 9; i++) ...{
                      CustomButton(
                        height: 50,
                        width: 50,
                        label: i.toString(),
                        onPressed: () {
                          con.setValue(i);
                        },
                      ),
                    },
                  ],
                ),
              ),
            ),
            const SizedBox(
              height: 20,
            ),
            if (!Sudoku.usermade)
              SizedBox(
                height: 50,
                child: Row(
                  mainAxisAlignment: MainAxisAlignment.center,
                  children: [
                    if (con.isFilledIn())
                      CustomButton(
                          label: "Am I right?",
                          onPressed: () {
                            bool result = con.checkPuzzleAndGetResult();
                            resultDialog(context, result, con);
                          }),
                    if (!con.isFilledIn())
                      CustomButton(
                          label: "Help...!",
                          onPressed: () {
                            con.getHint();
                          }),
                  ],
                ),
              ),
            if (Sudoku.usermade)
              SizedBox(
                height: 50,
                child: Row(
                  mainAxisAlignment: MainAxisAlignment.center,
                  children: [
                    CustomButton(
                      label: "Try solve!",
                      onPressed: () {
                        bool res = con.checkPuzzleAndGetResult();
                        resultDialog(context, res, con);
                      },
                    ),
                  ],
                ),
              ),
          ],
        );
      },
    );
  }

  Future<dynamic> resultDialog(
      BuildContext context, bool isCorrect, SudokuController con) {
    String isRightTitle = "Correct!";
    String isWrongTitle = "Too bad";
    String labelRight = "Back to home";
    String labelWrong = "Keep trying";
    return showDialog(
        context: context,
        builder: (BuildContext context) {
          return AlertDialog(
            title: Text(isCorrect ? isRightTitle : isWrongTitle),
            content: CustomButton(
              label: isCorrect ? labelRight : labelWrong,
              onPressed: () {
                Navigator.of(context).pop();
                if (isCorrect) {
                  Navigator.of(context).pop();
                  Future.delayed(const Duration(milliseconds: 200), () {
                    con.clearPuzzle();
                  });
                }
              },
            ),
          );
        });
  }

  Widget sudokuField(SudokuField field, SudokuController controller) {
    return GestureDetector(
      onTap: () {
        controller.selectField(field);
      },
      child: Container(
        height: 20,
        width: 20,
        decoration: BoxDecoration(
          border: Border.all(
            width: controller.model.selected == field ? 5 : 1,
            color:
                controller.model.selected == field ? Colors.red : Colors.black,
          ),
        ),
        padding: const EdgeInsets.all(5),
        child: Center(
          child: Text(
            field.value != null ? field.value.toString() : '',
          ),
        ),
      ),
    );
  }
}
