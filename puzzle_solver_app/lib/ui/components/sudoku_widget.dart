import 'package:flutter/material.dart';
import 'package:puzzle_solver_app/models/sudoku.dart';
import 'package:puzzle_solver_app/ui/components/sudoku_field_widget.dart';

class SudokuWidget extends StatefulWidget {
  const SudokuWidget({Key? key, required this.sudoku}) : super(key: key);

  final Sudoku sudoku;

  @override
  State<SudokuWidget> createState() => _SudokuWidgetState();
}

class _SudokuWidgetState extends State<SudokuWidget> {
  int? selectedField;
  @override
  Widget build(BuildContext context) {
    return GridView(
      gridDelegate: const SliverGridDelegateWithFixedCrossAxisCount(
        crossAxisCount: 9,
      ),
      children: widget.sudoku.fields
          .map(
            (e) => SudokField(
              field: e,
              selected: selectedField,
              onPressed: (idx) {
                setState(() {
                  selectedField = idx;
                });
              },
            ),
          )
          .toList(),
    );
  }
}
