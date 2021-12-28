using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace PuzzleSolver.Abstractions
{
    public interface IPuzzleController
    {
        public IActionResult Generate(int knownFields);
        public IActionResult CheckState(PuzzleTemplate puzzle);
        public IActionResult Resolve(List<PuzzleFieldDTO> fields);
    }
}
