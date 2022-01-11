import 'package:flutter_test/flutter_test.dart';
import 'package:mockito/annotations.dart';
import 'package:mockito/mockito.dart';
import 'package:momentum/momentum.dart';
import 'package:puzzle_solver_app/puzzles/sudoku/sudoku.dart';
import 'package:puzzle_solver_app/puzzles/sudoku/sudoku_controller.dart';
import 'package:puzzle_solver_app/puzzles/sudoku/sudoku_field.dart';
import 'package:puzzle_solver_app/puzzles/sudoku/sudoku_repository.dart';
import 'package:puzzle_solver_app/utils/http_service.dart';

import 'sudoku_controller_test.mocks.dart';

@GenerateMocks([HttpService])
void main() {
  HttpService mockedService = MockHttpService();

  when(mockedService.get("Database/GetAllNames")).thenAnswer(
    (_) => Future.value(
      [
        "test1",
        "test2",
        "test3",
        "test4",
        "test5",
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
    (_) => Exception("Error"),
  );

  when(mockedService.post(
    "Sudoku/GetHint",
    headers: {
      "Content-Type": "application/json",
    },
    body: '[{"Value": "1"},{"Value": null},{"Value": null},{"Value": "2"}]',
  )).thenAnswer(
    (_) => Future.value([1]),
  );

  when(mockedService.post(
    "Sudoku/GetHint",
    headers: {
      "Content-Type": "application/json",
    },
    body: '[{"Value": "3"},{"Value": null},{"Value": null},{"Value": "4"}]',
  )).thenAnswer(
    (_) => Future.value([1, 2]),
  );

  var sudokuController = SudokuController();
  sudokuController.sudokuRepository = SudokuRepository(mockedService);

  test("Get all puzzles", () async {
    var tester = MomentumTester(
      Momentum(
        controllers: [sudokuController],
      ),
    );
    await tester.init();
    List<String> expected = [
      "test1",
      "test2",
      "test3",
      "test4",
      "test5",
    ];

    List<String> puzzles = await sudokuController.allPuzzles();

    expect(puzzles, expected);
  });

  test("Load puzzle for playing", () async {
    var tester = MomentumTester(
      Momentum(
        controllers: [sudokuController],
      ),
    );
    await tester.init();
    Sudoku.usermade = false;

    await sudokuController.loadPuzzle("1");

    int expected = 9;

    expect(sudokuController.model.sudoku.fields.first.value, expected);
  });

  test("Load puzzle for solving", () async {
    var tester = MomentumTester(
      Momentum(
        controllers: [sudokuController],
      ),
    );
    await tester.init();
    Sudoku.usermade = true;

    await sudokuController.loadPuzzle("");

    int expectedLength = 81;

    expect(sudokuController.model.sudoku.fields.length, expectedLength);
  });

  test("Select a field", () async {
    var tester = MomentumTester(
      Momentum(
        controllers: [sudokuController],
      ),
    );
    await tester.init();

    SudokuField field = SudokuField();

    await sudokuController.selectField(field);

    expect(sudokuController.model.selected, field);
  });

  test("Set a valid number to selected field", () async {
    var tester = MomentumTester(
      Momentum(
        controllers: [sudokuController],
      ),
    );
    await tester.init();

    SudokuField field = SudokuField();

    sudokuController.selectField(field);
    sudokuController.setValue(1);

    int expected = 1;
    int expectedPotentialsLength = 0;

    expect(sudokuController.model.selected?.value, expected);
    expect(sudokuController.model.selected?.potentials.length,
        expectedPotentialsLength);
  });

  test("Set null to selected field (clearing)", () async {
    var tester = MomentumTester(
      Momentum(
        controllers: [sudokuController],
      ),
    );
    await tester.init();

    SudokuField field = SudokuField();

    sudokuController.selectField(field);
    sudokuController.setValue(null);

    int? expected;
    int expectedPotentialsLength = 9;

    expect(sudokuController.model.selected?.value, expected);
    expect(sudokuController.model.selected?.potentials.length,
        expectedPotentialsLength);
  });

  test("Minimal fields to solve achieved", () async {
    var tester = MomentumTester(
      Momentum(
        controllers: [sudokuController],
      ),
    );
    await tester.init();

    Sudoku sudoku = Sudoku();
    for (int i = 0; i < 10; i++) {
      SudokuField field = SudokuField();
      field.index = i;
      field.value = 1;
      sudoku.fields.add(field);
    }
    sudokuController.model.update(sudoku: sudoku);

    int minimalFieldsRequired = 5;

    sudokuController.minimalFields = minimalFieldsRequired;

    var result = sudokuController.minimalFieldsFilledIn();

    bool expected = true;

    expect(result, expected);
  });

  test("Minimal fields not achieved", () async {
    var tester = MomentumTester(
      Momentum(
        controllers: [sudokuController],
      ),
    );
    await tester.init();

    Sudoku sudoku = Sudoku();
    for (int i = 0; i < 10; i++) {
      SudokuField field = SudokuField();
      field.index = i;
      field.value = 1;
      sudoku.fields.add(field);
    }
    sudokuController.model.update(sudoku: sudoku);

    int minimalFieldsRequired = 20;

    sudokuController.minimalFields = minimalFieldsRequired;

    var result = sudokuController.minimalFieldsFilledIn();

    bool expected = false;

    expect(result, expected);
  });

  test("Amount of fields that need to be filled in before minimum is satisfied",
      () async {
    var tester = MomentumTester(
      Momentum(
        controllers: [sudokuController],
      ),
    );
    await tester.init();

    Sudoku sudoku = Sudoku();
    for (int i = 0; i < 10; i++) {
      SudokuField field = SudokuField();
      field.index = i;
      field.value = 1;
      sudoku.fields.add(field);
    }
    sudokuController.model.update(sudoku: sudoku);

    int minimalFieldsRequired = 17;

    sudokuController.minimalFields = minimalFieldsRequired;

    var result = sudokuController.fieldToFillMinimal();

    int expected = 7;

    expect(result, expected);
  });

  test("Set and get solving status", () async {
    var tester = MomentumTester(
      Momentum(
        controllers: [sudokuController],
      ),
    );
    await tester.init();

    sudokuController.setSolvingStatus(true);
    var actual = sudokuController.getSolvingStatus();

    bool expected = true;

    expect(sudokuController.model.isSolving, expected);
    expect(actual, expected);
  });

  test("Get puzzle result with succes", () async {
    var tester = MomentumTester(
      Momentum(
        controllers: [sudokuController],
      ),
    );
    await tester.init();

    Sudoku sudoku = Sudoku();
    sudoku.fields.add(SudokuField(value: 1));

    sudokuController.model.update(sudoku: sudoku);

    var result = await sudokuController.checkPuzzleAndGetResult();

    bool expected = true;

    expect(result, expected);
  });

  test("Get puzzle result with failure", () async {
    var tester = MomentumTester(
      Momentum(
        controllers: [sudokuController],
      ),
    );
    await tester.init();

    Sudoku sudoku = Sudoku();
    sudoku.fields.add(SudokuField(value: 2));

    sudokuController.model.update(sudoku: sudoku);

    var result = await sudokuController.checkPuzzleAndGetResult();

    bool expected = false;

    expect(result, expected);
  });

  test("Clear puzzle", () async {
    var tester = MomentumTester(
      Momentum(
        controllers: [sudokuController],
      ),
    );
    await tester.init();

    Sudoku sudoku = Sudoku();
    sudoku.fields.add(SudokuField(value: 1));

    sudokuController.model.update(sudoku: sudoku);

    sudokuController.clearPuzzle();

    int expected = 0;

    expect(sudokuController.model.sudoku.fields.length, expected);
  });

  test("All fields filled in", () async {
    var tester = MomentumTester(
      Momentum(
        controllers: [sudokuController],
      ),
    );
    await tester.init();

    Sudoku sudoku = Sudoku();
    sudoku.fields.add(SudokuField(value: 1));
    sudoku.fields.add(SudokuField(value: 1));
    sudoku.fields.add(SudokuField(value: 1));
    sudoku.fields.add(SudokuField(value: 1));

    sudokuController.model.update(sudoku: sudoku);

    var result = sudokuController.isFilledIn();

    bool expected = true;

    expect(result, expected);
  });

  test("Not all fields filled in", () async {
    var tester = MomentumTester(
      Momentum(
        controllers: [sudokuController],
      ),
    );
    await tester.init();

    Sudoku sudoku = Sudoku();
    sudoku.fields.add(SudokuField(value: 1));
    sudoku.fields.add(SudokuField(value: 1));
    sudoku.fields.add(SudokuField());
    sudoku.fields.add(SudokuField());

    sudokuController.model.update(sudoku: sudoku);

    var result = sudokuController.isFilledIn();

    bool expected = false;

    expect(result, expected);
  });

  test("Get potentials of selected field with value", () async {
    var tester = MomentumTester(
      Momentum(
        controllers: [sudokuController],
      ),
    );
    await tester.init();

    SudokuField field = SudokuField(value: 1);

    sudokuController.selectField(field);

    var result = sudokuController.getPotentials();

    List expected = [];

    expect(result, expected);
  });

  test("Get potentials of selected field without value", () async {
    var tester = MomentumTester(
      Momentum(
        controllers: [sudokuController],
      ),
    );
    await tester.init();

    SudokuField field = SudokuField(value: 1);

    sudokuController.selectField(field);
    sudokuController.setValue(null);

    var result = sudokuController.getPotentials();

    List expected = [1, 2, 3, 4, 5, 6, 7, 8, 9];

    expect(result, expected);
  });

  test("Get hint where potentials is one options", () async {
    var tester = MomentumTester(
      Momentum(
        controllers: [sudokuController],
      ),
    );
    await tester.init();

    Sudoku sudoku = Sudoku();

    sudoku.fields.add(SudokuField(value: 1));
    sudoku.fields.add(SudokuField());
    sudoku.fields.add(SudokuField());
    sudoku.fields.add(SudokuField(value: 2));

    sudokuController.model.update(sudoku: sudoku);

    await sudokuController.getHint();

    var expectedField = sudokuController.model.sudoku.fields
        .firstWhere((element) => element.value == null);

    var expectedPotentials = [1];

    expect(sudokuController.model.selected, expectedField);
    expect(sudokuController.getPotentials(), expectedPotentials);
  });

  test("Get hint where potentials are more options", () async {
    var tester = MomentumTester(
      Momentum(
        controllers: [sudokuController],
      ),
    );
    await tester.init();

    Sudoku sudoku = Sudoku();

    sudoku.fields.add(SudokuField(value: 3));
    sudoku.fields.add(SudokuField());
    sudoku.fields.add(SudokuField());
    sudoku.fields.add(SudokuField(value: 4));

    sudokuController.model.update(sudoku: sudoku);

    await sudokuController.getHint();

    var expectedField = sudokuController.model.sudoku.fields
        .firstWhere((element) => element.value == null);

    var expectedPotentials = [1, 2];

    expect(sudokuController.model.selected, expectedField);
    expect(sudokuController.getPotentials(), expectedPotentials);
  });
}
