using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace PuzzleSolver.Abstractions
{
    public interface IPuzzleController
    {
        public string Generate(int knownFields);
        public bool CheckState(PuzzleTemplate puzzle);
        public IActionResult Resolve(List<PuzzleField> fields);
    }
}
