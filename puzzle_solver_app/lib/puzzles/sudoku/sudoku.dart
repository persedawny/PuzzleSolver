import 'package:puzzle_solver_app/puzzles/sudoku/sudoku_field.dart';

class Sudoku {
  static bool usermade = true;
  Sudoku();

  List<SudokuField> fields = [];

  Sudoku fromJson(List json) {
    for (int i = 0; i < json.length; i++) {
      SudokuField field = SudokuField();
      field.index = i;
      field.value =
          json[i]['Value'] != null ? int.parse(json[i]['Value']) : null;
      if (field.value == null) field.potentials = [1, 2, 3, 4, 5, 6, 7, 8, 9];
      fields.add(field);
    }

    return this;
  }

  String toJson() {
    String json = '[';
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
    json += ']';
    return json;
  }

  void setValue(int i, int value) {
    fields[i].value = value;
  }
}
