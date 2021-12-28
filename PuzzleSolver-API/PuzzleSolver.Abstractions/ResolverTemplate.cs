using System.Collections.Generic;

namespace PuzzleSolver.Abstractions
{
    public abstract class ResolverTemplate
    {
        public abstract PuzzleTemplate Resolve(IEnumerable<PuzzleFieldDTO> fields);
    }
}
