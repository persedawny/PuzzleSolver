using PuzzleSolver.Models.DTO;
using System.Collections.Generic;

namespace PuzzleSolver.Abstractions
{
    public abstract class ResolverTemplate
    {
        public abstract PuzzleTemplate Resolve(IEnumerable<PuzzleFieldDTO> puzzleFields);

        public abstract IEnumerable<string> GetHint(IEnumerable<PuzzleFieldDTO> puzzleFields);
    }
}
