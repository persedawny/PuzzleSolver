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
    for (int i = 0; i < fields.length; i++) {
      if (fields[i].value == null) {
        i == fields.length - 1
            ? json += '{"Value": ${fields[i].value}}'
            : json += '{"Value": ${fields[i].value}},';
      } else {
        i == fields.length - 1
            ? json += '{"Value": "${fields[i].value}"}'
            : json += '{"Value": "${fields[i].value}"},';
      }
    }
    json += "]";
    return json;
  }
}
