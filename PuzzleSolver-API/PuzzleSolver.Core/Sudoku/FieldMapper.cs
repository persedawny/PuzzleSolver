using PuzzleSolver.Abstractions;
using System.Collections.Generic;

namespace PuzzleSolver.Core.Sudoku
{
    internal class FieldMapper : IMapper<Field>
    {
        public List<Field> MapListToImplementation(List<PuzzleField> fields)
        {
            var sudokuList = new List<Field>();

            foreach (var field in fields)
                sudokuList.Add(new Field(field.Value) { Index = field.Index, PotentialValues = field.PotentialValues });

            return sudokuList;
        }

        public List<PuzzleField> MapListToAbstraction(List<Field> fields)
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
