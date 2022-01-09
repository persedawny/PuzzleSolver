using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace PuzzleSolver.Abstractions
{
    public interface IPuzzleController
    {
        public IActionResult Generate(int knownFields);
        public IActionResult Resolve(IEnumerable<PuzzleFieldDTO> fields);
    }
}
