import 'package:flutter_test/flutter_test.dart';
import 'package:mockito/annotations.dart';
import 'package:mockito/mockito.dart';
import 'package:puzzle_solver_app/puzzles/sudoku/sudoku.dart';
import 'package:puzzle_solver_app/puzzles/sudoku/sudoku_field.dart';
import 'package:puzzle_solver_app/puzzles/sudoku/sudoku_repository.dart';
import 'package:puzzle_solver_app/utils/http_service.dart';

import 'sudoku_repository_test.mocks.dart';

@GenerateMocks([HttpService])
void main() {
  HttpService mockedService = MockHttpService();
  SudokuRepository sudokuRepository = SudokuRepository(mockedService);

  when(mockedService.get("Database/GetAllNames")).thenAnswer(
    (_) => Future.value(
      [
        "test1",
        "test2",
        "test3",
        "test4",
        "test5",
        "test6",
        "test7",
        "test8",
        "test9",
        "test10"
      ],
    ),
  );

  when(mockedService.get("Database/GetPuzzleByID?id=1")).thenAnswer(
    (_) => Future.value(
      [
        {"Value": "9"}
      ],
    ),
  );

  when(mockedService.get("Database/GetPuzzleByID?id=2")).thenThrow(
    Exception(),
  );

  when(mockedService.post(
    "Sudoku/Resolve",
    headers: {
      "Content-Type": "application/json",
    },
    body: '[{"Value": "1"}]',
  )).thenAnswer(
    (_) => Future.value(
      [
        {"value": "5"},
      ],
    ),
  );

  when(mockedService.post(
    "Sudoku/Resolve",
    headers: {
      "Content-Type": "application/json",
    },
    body: '[{"Value": "2"}]',
  )).thenThrow(
    Exception(),
  );

  test("Retrieve list of puzzles", () async {
    List<String> expected = [
      "test1",
      "test2",
      "test3",
      "test4",
      "test5",
      "test6",
      "test7",
      "test8",
      "test9",
      "test10"
    ];

    var result = await sudokuRepository.getAllPuzzles();

    expect(result, expected);
  });

  test("Retrieve puzzle by given ID", () async {
    int expected = 9;

    var result = await sudokuRepository.getPuzzleById("1");

    expect(result.fields.first.value, expected);
  });

  test("Unable to retrieve puzzle by given ID", () async {
    try {
      await sudokuRepository.getPuzzleById("2");
    } catch (e) {
      expect(e, isA<Exception>());
      expect(e.toString(), "Exception");
    }
  });

  test("Solve a puzzle and compare the first value", () async {
    Sudoku sudoku = Sudoku();
    sudoku.fields.add(SudokuField(value: 1));
    int expected = 5;

    var result = await sudokuRepository.solvePuzzle(sudoku) as Sudoku;

    expect(result.fields.first.value, expected);
  });

  test("Solving failed should throw exception", () async {
    Sudoku sudoku = Sudoku();
    sudoku.fields.add(SudokuField(value: 2));
    try {
      await sudokuRepository.solvePuzzle(sudoku);
    } catch (e) {
      expect(e, isA<Exception>());
      expect(e.toString(), "Exception");
    }
  });
}
