using System.Collections.Generic;

namespace PuzzleSolver.Abstractions
{
    public abstract class ResolverTemplate
    {
        public abstract string Resolve(List<PuzzleField> puzzleFields);                     
        public abstract bool IsResolved(List<PuzzleField> puzzleFields);
    }
}
