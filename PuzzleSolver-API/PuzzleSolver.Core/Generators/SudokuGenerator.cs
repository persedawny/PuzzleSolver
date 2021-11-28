using PuzzleSolver.Abstractions;
using PuzzleSolver.Core.Validators;
using System;

namespace PuzzleSolver.Core.Generators
{
    internal class SudokuGenerator : GeneratorTemplate
    {
        public SudokuGenerator(SudokuValidator sudokuValidator) : base(sudokuValidator) { }

        public override string Generate(int knownFields)
        {
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

            do
            {
                var row = rnd.Next(1, 10);
                var column = rnd.Next(1, 10);
                var idx = (row * column) - 1;
                if (arr[idx].Contains('0'))
                {
                    var number = rnd.Next(1, 10);
                    arr[idx] = arr[idx].Replace("0", $"{number}");
                    if (base.isValid(string.Join(',', arr)))
                    {
                        fieldsFilled++;
                    }
                    else
                    {
                        arr[idx] = arr[idx].Replace($"{number}", "0");
                    }

                }
            } while (fieldsFilled < knownFields);

            var res = string.Join(',', arr);
            return res;
        }
    }
}