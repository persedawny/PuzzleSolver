import 'package:flutter/material.dart';
import 'package:puzzle_solver_app/main.dart';
import 'package:puzzle_solver_app/utils/puzzle_enum_extension.dart';

class Solve extends StatefulWidget {
  const Solve({Key? key}) : super(key: key);

  @override
  _SolveState createState() => _SolveState();
}

class _SolveState extends State<Solve> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text("Solving ${Home.selectedPuzzle.toPuzzleString()}"),
      ),
    );
  }
}
