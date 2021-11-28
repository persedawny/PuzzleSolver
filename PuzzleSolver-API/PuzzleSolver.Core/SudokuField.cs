using System.Collections.Generic;
using System.Linq;

namespace PuzzleSolver.Core
{
    internal class SudokuField
    {
        public int? Value;
        public int Index;
        public List<int> PotentialValues = new();

        public bool HasValue { get => Value != null; }

        public SudokuField(int? value = null)
        {
            Value = value;

            if (value == null)
            {
                PotentialValues = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            }
        }

        public int GetRowID()
        {
            // TODO: Magic numbers... moeten we wat voor verzinnen
            return Index / 9;
        }

        public int GetColumnID()
        {
            // TODO: Magic numbers... moeten we wat voor verzinnen
            return Index - (GetRowID() * 9);
        }

        public int GetBlockID()
        {
            // TODO: Magic numbers... moeten we wat voor verzinnen
            int boxRow = GetRowID() / 3;
            int boxCol = GetColumnID() / 3;
            return (boxRow * 3) + boxCol;
        }

        public SudokuField Copy()
        {
            return new SudokuField(Value)
            {
                Index = Index,
                PotentialValues = PotentialValues.ToList()
            };
        }
    }
}
