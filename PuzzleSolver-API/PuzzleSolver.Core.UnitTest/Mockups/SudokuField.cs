using PuzzleSolver.Abstractions;
using System.Collections.Generic;

namespace PuzzleSolver.Core.UnitTest.Mockups
{
    internal class SudokuField : PuzzleFieldTemplate
    {
        public SudokuField(string? value = null) : base()
        {
            Value = value;

            if (value == null)
            {
                PotentialValues = new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            }
        }

        public override int GetBlockID()
        {
            throw new System.NotImplementedException();
        }

        public override int GetColumnID()
        {
            throw new System.NotImplementedException();
        }

        public override int GetRowID()
        {
            throw new System.NotImplementedException();
        }
    }
}
