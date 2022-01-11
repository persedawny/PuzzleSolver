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
}
