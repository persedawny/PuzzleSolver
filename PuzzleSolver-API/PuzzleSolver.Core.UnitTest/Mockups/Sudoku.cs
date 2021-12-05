using PuzzleSolver.Abstractions;
using System;
using System.Collections.Generic;

namespace PuzzleSolver.Core.UnitTest.Mockups
{
    internal class Sudoku : PuzzleTemplate
    {
        public Sudoku(List<PuzzleField> fields) : base(fields)
        {
        }

        public override string GetContentAsJson()
        {
            throw new NotImplementedException();
        }

        public override void SetContentFromJson(string json)
        {
            throw new NotImplementedException();
        }
    }
}
