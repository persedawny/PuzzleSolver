using PuzzleSolver.Abstractions;
using System;
using System.Collections.Generic;

namespace PuzzleSolver.Core.Sudoku
{
    internal class Generator : GeneratorTemplate
    {
        public Generator(Validator sudokuValidator) : base(sudokuValidator) { }

        public override PuzzleTemplate Generate(int knownFields)
        {
            Random rnd = new Random();

            List<PuzzleField> fields = new List<PuzzleField>();

            for (int i = 0; i < 81; i++)
            {
                fields.Add(new Field()
                {
                    Index = i
                }); ;
            }

            var fieldsFilled = 0;

            while (fieldsFilled < knownFields)
            {
                var row = rnd.Next(1, 10);
                var column = rnd.Next(1, 10);
                var idx = row * column - 1;

                Field field = fields[idx] as Field;

                if (field.Value == null)
                {
                    var number = rnd.Next(1, 10);
                    field.Value = number.ToString();

                    PuzzleTemplate puzzle = new Puzzle(fields);


                    if (isValid(puzzle))
                    {
                        fieldsFilled++;
                    }
                    else
                    {
                        field.Value = null;
                    }
                }
            }

            PuzzleTemplate finalPuzzle = new Puzzle(fields);
            return finalPuzzle;
        }
    }
}