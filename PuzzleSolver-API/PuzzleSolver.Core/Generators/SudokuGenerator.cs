using PuzzleSolver.Abstractions;
using PuzzleSolver.Core.PuzzleTemplates;
using PuzzleSolver.Core.Validators;
using System;
using System.Collections.Generic;

namespace PuzzleSolver.Core.Generators
{
    internal class SudokuGenerator : GeneratorTemplate
    {
        public SudokuGenerator(SudokuValidator sudokuValidator) : base(sudokuValidator) { }

        public override PuzzleTemplate Generate(int knownFields)
        {
            Random rnd = new Random();

            List<PuzzleField> fields = new List<PuzzleField>();

            for (int i = 0; i < 81; i++) {
                fields.Add(new SudokuField()
                {
                    Index = i
                }); ;
            }

            var fieldsFilled = 0;

            while (fieldsFilled < knownFields)
            {
                var row = rnd.Next(1, 10);
                var column = rnd.Next(1, 10);
                var idx = (row * column) - 1;

                SudokuField field = fields[idx] as SudokuField;

                if (field.Value == null)
                {
                    var number = rnd.Next(1, 10);
                    field.Value = number;

                    PuzzleTemplate puzzle = new Sudoku(fields);


                    if (base.isValid(puzzle))
                    {
                        fieldsFilled++;
                    }
                    else
                    {
                        field.Value = null;
                    }
                }
            }

            PuzzleTemplate finalPuzzle = new Sudoku(fields);
            return finalPuzzle;
        }
    }
}