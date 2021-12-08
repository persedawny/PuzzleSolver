import 'dart:math';

import 'package:flutter/material.dart';
import 'package:puzzle_solver_app/main.dart';
import 'package:puzzle_solver_app/models/field.dart';
import 'package:puzzle_solver_app/models/sudoku.dart';
import 'package:puzzle_solver_app/ui/components/sudoku_widget.dart';
import 'package:puzzle_solver_app/ui/utils/button.dart';
import 'package:puzzle_solver_app/utils/puzzle_enum_extension.dart';

class Play extends StatefulWidget {
  const Play({Key? key}) : super(key: key);

  @override
  _PlayState createState() => _PlayState();
}

class _PlayState extends State<Play> {
  late Sudoku sudoku;
  @override
  void initState() {
    super.initState();
    List<Field> fields = [];
    for (int i = 0; i < 81; i++) {
      Random rnd = Random();
      bool r = rnd.nextBool();
      fields.add(Field(index: i, value: r ? null : 1));
    }
    sudoku = Sudoku(fields: fields);
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text("Playing ${Home.selectedPuzzle.toPuzzleString()}"),
      ),
      body: Column(
        mainAxisAlignment: MainAxisAlignment.center,
        children: [
          SizedBox(
            height: MediaQuery.of(context).size.height * 0.4,
            width: MediaQuery.of(context).size.height * 0.4,
            child: SudokuWidget(
              sudoku: sudoku,
            ),
          ),
          Container(
            height: 20,
          ),
          Wrap(
            children: [
              for (int i = 1; i <= 9; i++) ...{
                CustomButton(
                  height: 50,
                  width: 50,
                  label: i.toString(),
                  onPressed: () {
                    if (SudokuWidget.selectedField != null) {
                      setState(() {
                        sudoku.fields[SudokuWidget.selectedField!].value = i;
                      });
                    }
                  },
                ),
              },
            ],
          )
        ],
      ),
    );
  }
}
