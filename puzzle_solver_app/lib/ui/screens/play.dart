import 'package:flutter/material.dart';
import 'package:puzzle_solver_app/main.dart';
import 'package:puzzle_solver_app/utils/puzzle_enum_extension.dart';

class Play extends StatefulWidget {
  const Play({Key? key}) : super(key: key);

  @override
  _PlayState createState() => _PlayState();
}

class _PlayState extends State<Play> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text("Playing ${Home.selectedPuzzle.toPuzzleString()}"),
      ),
    );
  }
}
