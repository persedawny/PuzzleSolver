﻿using PuzzleSolver.Abstractions;
using System.Collections.Generic;

namespace PuzzleSolver.Core.Sudoku
{
    internal class FieldMapper
    {
        public static List<Field> MapListToSudoku(List<PuzzleField> fields)
        {
            var sudokuList = new List<Field>();

            foreach (var field in fields)
                sudokuList.Add(new Field(field.Value));

            return sudokuList;
        }

        public static List<PuzzleField> MapListToAbstraction(List<Field> fields)
        {
            var sudokuList = new List<PuzzleField>();

            foreach (var field in fields)
                sudokuList.Add(new PuzzleField()
                {
                    Index = field.Index,
                    Value = field.Value,
                    PotentialValues = field.PotentialValues
                });

            return sudokuList;
        }
    }
}