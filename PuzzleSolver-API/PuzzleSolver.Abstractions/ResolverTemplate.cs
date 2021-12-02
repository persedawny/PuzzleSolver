using System.Collections.Generic;

namespace PuzzleSolver.Abstractions
{
    public abstract class ResolverTemplate
    {
        public abstract string Resolve(PuzzleTemplate puzzle);
        public abstract bool IsResolved(PuzzleTemplate puzzle);
    }
}
