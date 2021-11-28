using PuzzleSolver.Abstractions;
using System;

namespace PuzzleSolver.Core.UnitTest.Mockups
{
    internal class MockupSudokuGenerator : GeneratorTemplate
    {
        public InvocationService InvocationService = new InvocationService();

        public MockupSudokuGenerator(MockupSudokuValidator sudokuValidator) : base(sudokuValidator) { }

        public override string Generate(int knownFields)
        {
            InvocationService.AddOrUpdateInvocation("Generate");

            Random rnd = new Random();

            var puzzleJson = "{sudoku: [" +
                "[0, 0, 0, 0, 0, 0, 0, 0, 0]," +
                "[0, 0, 0, 0, 0, 0, 0, 0, 0]," +
                "[0, 0, 0, 0, 0, 0, 0, 0, 0]," +
                "[0, 0, 0, 0, 0, 0, 0, 0, 0]," +
                "[0, 0, 0, 0, 0, 0, 0, 0, 0]," +
                "[0, 0, 0, 0, 0, 0, 0, 0, 0]," +
                "[0, 0, 0, 0, 0, 0, 0, 0, 0]," +
                "[0, 0, 0, 0, 0, 0, 0, 0, 0]," +
                "[0, 0, 0, 0, 0, 0, 0, 0, 0]" +
              "]}";

            var fieldsFilled = 0;
            var arr = puzzleJson.Split(',');

            do {
                var row = rnd.Next(1, 10);
                var column = rnd.Next(1, 10);
                var idx = (row * column) - 1;
                if (arr[idx].Contains('0'))
                {
                    var number = 4;
                    arr[idx] = arr[idx].Replace("0", $"{number}");
                    fieldsFilled++;
                }
            } while (fieldsFilled < knownFields);

            var res = string.Join(',', arr);
            return res;
        }
    }
}
