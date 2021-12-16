using PuzzleSolver.Abstractions;
using System.Collections.Generic;

namespace PuzzleSolver.Core.Sudoku
{
    internal class Validator : IValidator
    {
        private readonly IMapper<Field> mapper;

        public Validator(IMapper<Field> mapper)
        {
            this.mapper = mapper;
        }

        public bool IsValid(List<PuzzleField> fields)
        {
            var sudokuFields = mapper.MapListToImplementation(fields);

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
