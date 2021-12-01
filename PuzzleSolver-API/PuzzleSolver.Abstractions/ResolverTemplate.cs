using System.Collections.Generic;

namespace PuzzleSolver.Abstractions
{
    public abstract class ResolverTemplate
    {
        public abstract string Resolve(string puzzleJson);                     
        public abstract bool IsResolved(string puzzleJson);
    }
}
