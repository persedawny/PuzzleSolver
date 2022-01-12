using PuzzleSolver.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PuzzleSolver.Core.Sudoku
{
    internal class Generator : GeneratorTemplate
    {
        private const int AmountOfFields = 81;
        private const int MinimalFieldValue = 1;
        private const int MaxFieldValuePlusOne = 10;

        public Generator(Validator sudokuValidator) : base(sudokuValidator) { }

        public override PuzzleTemplate Generate(int knownFields)
        {
            Random rnd = new Random();

            List<PuzzleFieldTemplate> fields = new List<PuzzleFieldTemplate>();
            List<int> indexes = new List<int>();

            for (int i = 0; i < AmountOfFields; i++)
            {
                indexes.Add(i);
                fields.Add(new Field()
                {
                    Index = i
                }); ;
            }

            var fieldsFilled = 0;

            while (fieldsFilled < knownFields)
            {
                var idx = rnd.Next(indexes.Count);

                Field field = fields[indexes[idx]] as Field;

                if (field.Value == null)
                {
                    var number = rnd.Next(MinimalFieldValue, MaxFieldValuePlusOne);
                    field.Value = number.ToString();

                    PuzzleTemplate puzzle = new Puzzle(fields);


                    if (isValid(puzzle))
                    {
                        fieldsFilled++;
                        indexes = indexes.Where(x => x != field.Index).ToList();
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