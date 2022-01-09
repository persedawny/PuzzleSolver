using PuzzleSolver.Abstractions;
using System.Collections.Generic;

namespace PuzzleSolver.Core.Sudoku
{
    internal class Validator : IValidator
    {
        public Validator() { }

        public bool IsValid(List<PuzzleFieldTemplate> fields)
        {
            foreach (var field in fields)
            {
                foreach (var compareField in fields)
                {
                    if (field.Index == compareField.Index)
                        continue;

                    if (field.GetColumnID() != compareField.GetColumnID() && field.GetRowID() != compareField.GetRowID() && field.GetBlockID() != compareField.GetBlockID())
                        continue;

                    if (field.Value == compareField.Value)
                        return false;
                }
            }

            return true;
        }
    }
}
