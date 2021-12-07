import 'package:puzzle_solver_app/enums/puzzle.dart';

extension PuzzleToString on Puzzle {
  String toPuzzleString() {
    String text = toString().split('.').last;
    return text[0].toUpperCase() + text.substring(1);
  }
}
