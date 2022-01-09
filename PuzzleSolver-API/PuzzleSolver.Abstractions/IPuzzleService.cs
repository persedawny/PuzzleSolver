using System.Collections.Generic;

namespace PuzzleSolver.Abstractions
{
    public interface IPuzzleService
    {
        public PuzzleTemplate Generate(int knownFields);
        public PuzzleTemplate Resolve(IEnumerable<PuzzleFieldDTO> fields);
    }
}
