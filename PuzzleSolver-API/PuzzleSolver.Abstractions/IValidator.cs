using System.Collections.Generic;

namespace PuzzleSolver.Abstractions
{
    public interface IValidator
    {
        public bool IsValid(List<PuzzleField> fields);
    }
}
