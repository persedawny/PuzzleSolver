using PuzzleSolver.Models.DTO;
using System.Collections.Generic;

namespace PuzzleSolver.Abstractions
{
    public interface IResolver
    {
        PuzzleTemplate Resolve(IEnumerable<PuzzleFieldDTO> puzzleFields);

        IEnumerable<string> GetHint(IEnumerable<PuzzleFieldDTO> puzzleFields);
    }
}
