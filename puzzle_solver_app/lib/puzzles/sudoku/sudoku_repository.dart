import 'package:puzzle_solver_app/puzzles/puzzle.dart';
import 'package:puzzle_solver_app/puzzles/puzzle_repository.dart';
import 'package:puzzle_solver_app/puzzles/sudoku/sudoku.dart';
import 'package:puzzle_solver_app/utils/http_service.dart';

class SudokuRepository implements PuzzleRepository {
  final HttpService httpService;

  SudokuRepository(this.httpService);

  @override
  Future<List<String>> getAllPuzzles() async {
    return (await httpService.get("Database/GetAllNames")).cast<String>();
  }

  @override
  Future<Sudoku> getPuzzleById(String id) async {
    return Sudoku()
            .fromJson(await httpService.get("Database/GetPuzzleByID?id=$id"))
        as Sudoku;
  }

  @override
  Future<Puzzle> solvePuzzle(Puzzle puzzle) async {
    Sudoku sudoku = puzzle as Sudoku;

    List json = await httpService.post(
      "Sudoku/Resolve",
      headers: {
        "Content-Type": "application/json",
      },
      body: sudoku.toJson(),
    );

    for (int i = 0; i < json.length; i++) {
      sudoku.setValue(i, int.parse(json[i]["value"]));
    }

    return sudoku;
  }

  @override
  Future<List<int>> getHint(Puzzle puzzle) async {
    Sudoku sudoku = puzzle as Sudoku;

    List<dynamic> res = await httpService.post(
      "Sudoku/GetHint",
      headers: {
        "Content-Type": "application/json",
      },
      body: sudoku.toJson(),
    );
    return res.map((e) => int.parse(e.toString())).toList();
  }

  @override
  Future<void> savePuzzle(Puzzle puzzle) async {
    Sudoku sudoku = puzzle as Sudoku;

    await httpService.post(
      "Database/InsertPuzzle",
      headers: {
        "Content-Type": "application/json",
      },
      body: sudoku.toJson(),
      shouldReturnBody: false,
    );
  }
}
