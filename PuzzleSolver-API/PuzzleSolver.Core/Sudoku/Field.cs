using PuzzleSolver.Abstractions;
using System.Collections.Generic;
using System.Linq;

namespace PuzzleSolver.Core.Sudoku
{
    internal class Field : PuzzleFieldTemplate
    {
        private const int AmountOfColumnsAndRows = 9;
        private const int AmountOfBoxesPerRowAndColumn = 3;

        public Field(string? value = null) : base()
        {
            Value = value;

            if (value == null)
            {
                PotentialValues = new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            }
        }

        public override int GetRowID()
        {
            return Index / AmountOfColumnsAndRows;
        }

        public override int GetColumnID()
        {
            return Index - GetRowID() * AmountOfColumnsAndRows;
        }

        public override int GetBlockID()
        {
            int boxRow = GetRowID() / AmountOfBoxesPerRowAndColumn;
            int boxColumn = GetColumnID() / AmountOfBoxesPerRowAndColumn;
            return boxRow * AmountOfBoxesPerRowAndColumn + boxColumn;
        }

        public Field Copy()
        {
            return new Field(Value)
            {
                Index = Index,
                PotentialValues = PotentialValues.ToList()
            };
        }

        public bool IsRelatedTo(Field field)
        {
            return field.GetBlockID() == GetBlockID() ||
                        field.GetColumnID() == GetColumnID() ||
                        field.GetRowID() == GetRowID();
        }
    }
}
