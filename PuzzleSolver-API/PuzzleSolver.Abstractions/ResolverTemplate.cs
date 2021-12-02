using System.Collections.Generic;

namespace PuzzleSolver.Abstractions
{
    public abstract class ResolverTemplate<T> where T : PuzzleField
    {
        public abstract string Resolve(List<T> puzzlefields);
        public abstract bool IsResolved(List<T> puzzlefields);
    }
}
