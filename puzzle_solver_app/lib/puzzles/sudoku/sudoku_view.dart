import 'package:flutter/material.dart';
import 'package:momentum/momentum.dart';
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

        return Column(
          mainAxisAlignment: MainAxisAlignment.center,
          children: [
            SizedBox(
              height: MediaQuery.of(context).size.height * 0.4,
              width: MediaQuery.of(context).size.height * 0.4,
              child: GridView(
                gridDelegate: const SliverGridDelegateWithFixedCrossAxisCount(
                  crossAxisCount: 9,
                ),
                children: con.model.fields
                    .map(
                      (e) => sudokuField(e, con),
                    )
                    .toList(),
              ),
            ),
            Container(
              height: 20,
            ),
            SizedBox(
              width: MediaQuery.of(context).size.height * 0.4,
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
            )
          ],
        );
      },
    );
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
