using System.Collections.Generic;

namespace PuzzleSolver.Abstractions
{
    public interface IPuzzleService
    {
        public PuzzleTemplate Generate(int knownFields);
        public bool CheckState(PuzzleTemplate puzzle);
        public PuzzleTemplate Resolve(List<PuzzleField> fields);
    }
}
