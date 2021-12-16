import 'package:puzzle_solver_app/puzzles/sudoku/sudoku_field.dart';

class Sudoku {
  static bool usermade = true;
  Sudoku();

  List<SudokuField> fields = [];

  Sudoku fromJson(List json) {
    for (Map item in json) {
      SudokuField field = SudokuField();
      field.index = item['Index'];
      field.value = item['Value'];
      fields.add(field);
    }

    return this;
  }

  String toJson() {
    String json = "[";
    for (SudokuField field in fields) {
      String potential = "";
      field.value == null
          ? potential = "[]"
          : '[ "1", "2", "3", "4", "5", "6", "7", "8", "9" ]';
      json +=
          '{"Value": ${field.value},"Index": ${field.index},"PotentialValues": $potential}';
    }
    json += "]";
    return json;
  }
}
