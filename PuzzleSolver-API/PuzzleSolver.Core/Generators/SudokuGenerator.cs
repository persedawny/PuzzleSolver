using PuzzleSolver.Abstractions;
using PuzzleSolver.Core.Validators;
using PuzzleSolver.Core.PuzzleTemplates;
using System;
using System.Collections.Generic;

namespace PuzzleSolver.Core.Generators
{
    internal class SudokuGenerator : GeneratorTemplate
    {
        public SudokuGenerator(SudokuValidator sudokuValidator) : base(sudokuValidator) { }

        public override string Generate(int knownFields)
        {
            Random rnd = new Random();

            List<SudokuField> puzzleItems = new List<SudokuField>();

            for (int i = 0; i < 81; i++)
            {
                puzzleItems.Add(new SudokuField() { Index = i });
            }

            var fieldsFilled = 0;

            while (fieldsFilled < knownFields)
            {
                var row = rnd.Next(1, 10);
                var column = rnd.Next(1, 10);
                var idx = (row * column) - 1;

                if (puzzleItems[idx].Value == null)
                {
                    var number = rnd.Next(1, 10);
                    puzzleItems[idx].Value = number;
                    Sudoku puzzle = new Sudoku(puzzleItems);
                    if (base.isValid(puzzle.GetContentAsJson()))
                    {
                        fieldsFilled++;
                    }
                    else
                    {
                        puzzleItems[idx].Value = null;
                    }
                }
            }

            Sudoku s = new Sudoku(puzzleItems);
            // Console.WriteLine(s.GetContentAsJson());
            // TODO: When puzzletemplates are used as return types and parameter this can be finalized
            return "";
        }
    }
}