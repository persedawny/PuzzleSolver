using PuzzleSolver.Models.DTO;
using System.Collections.Generic;

namespace PuzzleSolver.Abstractions
{
    public interface IPuzzleService
    {
        public PuzzleTemplate Generate(int knownFields);
        public PuzzleTemplate Resolve(IEnumerable<PuzzleFieldDTO> fields);
        public IEnumerable<string> GetHint(IEnumerable<PuzzleFieldDTO> fields);
    }
}
