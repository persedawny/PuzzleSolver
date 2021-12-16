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

        public override PuzzleTemplate GetFromJson(string json)
        {
            throw new NotImplementedException();
        }

        public override void LoopAndGetPotentialValues()
        {
            throw new NotImplementedException();
        }

        public override void SetIndexes()
        {
            throw new NotImplementedException();
        }
    }
}
