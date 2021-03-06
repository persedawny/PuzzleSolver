import 'package:puzzle_solver_app/puzzles/puzzle.dart';

abstract class PuzzleRepository {
  Future<Puzzle> solvePuzzle(Puzzle puzzle);
  Future<List<String>> getAllPuzzles();
  Future<Puzzle> getPuzzleById(String id);
  Future<List<int>> getHint(Puzzle puzzle);
  Future<void> savePuzzle(Puzzle puzzle);
}
