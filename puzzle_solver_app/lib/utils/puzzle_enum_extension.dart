import 'package:puzzle_solver_app/enums/puzzle_enum.dart';

extension PuzzleToString on PuzzleType {
  String toPuzzleString() {
    String text = toString().split('.').last;
    return text[0].toUpperCase() + text.substring(1);
  }
}
