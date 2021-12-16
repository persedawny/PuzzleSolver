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
    Response res = await post(
      uri,
      body: jsonEncode(sudoku.toJson()),
    );
    return sudoku;
  }
}
