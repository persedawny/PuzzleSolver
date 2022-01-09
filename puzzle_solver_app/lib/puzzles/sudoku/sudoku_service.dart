import 'dart:convert';

import 'package:http/http.dart';
import 'package:puzzle_solver_app/puzzles/sudoku/sudoku.dart';

class SudokuService {
  SudokuService({
    required this.baseUrl,
  });

  final String baseUrl;

  Future<Sudoku> getPuzzle(int knownFields) async {
    Uri uri = Uri.parse(baseUrl + "Sudoku/Generate?knownFields=$knownFields");

    Response res = await get(uri);

    List json = [];
    return Sudoku().fromJson(json);
  }

  solvePuzzle(Sudoku sudoku) async {
    Uri uri = Uri.parse(baseUrl + "Sudoku/Resolve");
    String body =
        '[{"Value": null},{"Value": null},{"Value": null},{"Value": "9"},{"Value": null},{"Value": null},{"Value": "8"},{"Value": "7"},{"Value": "2"},{"Value": "2"},{"Value": "4"},{"Value": null},{"Value": null},{"Value": null},{"Value": "1"},{"Value": null},{"Value": null},{"Value": null},{"Value": "3"},{"Value": null},{"Value": null},{"Value": null},{"Value": "5"},{"Value": null},{"Value": "6"},{"Value": null},{"Value": null},{"Value": "8"},{"Value": null},{"Value": null},{"Value": null},{"Value": "6"},{"Value": "2"},{"Value": null},{"Value": "5"},{"Value": null},{"Value": "5"},{"Value": "3"},{"Value": "9"},{"Value": null},{"Value": "8"},{"Value": null},{"Value": "7"},{"Value": null},{"Value": null},{"Value": null},{"Value": null},{"Value": null},{"Value": null},{"Value": "3"},{"Value": null},{"Value": "1"},{"Value": "4"},{"Value": null},{"Value": "6"},{"Value": "2"},{"Value": "1"},{"Value": null},{"Value": null},{"Value": null},{"Value": null},{"Value": null},{"Value": "3"},{"Value": null},{"Value": "7"},{"Value": null},{"Value": "8"},{"Value": null},{"Value": null},{"Value": "4"},{"Value": null},{"Value": null},{"Value": null},{"Value": null},{"Value": "5"},{"Value": null},{"Value": "1"},{"Value": null},{"Value": null},{"Value": "9"},{"Value": null}]';

    Response res = await post(
      uri,
      headers: {
        "Content-Type": "application/json",
      },
      body: body,
    );

    List json = jsonDecode(res.body);

    for (int i = 0; i < json.length; i++) {
      sudoku.setValue(i, int.parse(json[i]["value"]));
    }

    return sudoku;
  }
}
