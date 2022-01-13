import 'package:flutter/material.dart';
import 'package:puzzle_solver_app/puzzles/sudoku/sudoku_controller.dart';
import 'package:puzzle_solver_app/puzzles/sudoku/sudoku_field.dart';

class SudokuFieldWidget extends StatelessWidget {
  const SudokuFieldWidget({
    Key? key,
    required this.controller,
    required this.field,
  }) : super(key: key);

  final SudokuController controller;
  final SudokuField field;

  @override
  Widget build(BuildContext context) {
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
