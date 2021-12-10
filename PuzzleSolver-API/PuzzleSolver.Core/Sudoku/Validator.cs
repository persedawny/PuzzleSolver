using PuzzleSolver.Abstractions;
using System.Collections.Generic;

namespace PuzzleSolver.Core.Sudoku
{
    internal class Validator : IValidator
    {
        public bool IsValid(List<PuzzleField> fields)
        {
            var sudokuFields = FieldMapper.MapListToImplementation(fields);

            foreach (var field in sudokuFields)
            {
                foreach (var compareField in sudokuFields)
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
