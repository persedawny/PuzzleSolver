import 'package:puzzle_solver_app/puzzles/puzzle.dart';

abstract class PuzzleRepository {
  Future<Puzzle> solvePuzzle(Puzzle puzzle);
  Future<List<String>> getAllPuzzles();
  Future<Puzzle> getPuzzleById(String id);
}
