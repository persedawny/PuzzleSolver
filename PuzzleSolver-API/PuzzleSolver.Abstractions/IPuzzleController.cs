using Microsoft.AspNetCore.Mvc;
using PuzzleSolver.Models.DTO;
using System.Collections.Generic;

namespace PuzzleSolver.Abstractions
{
    public interface IPuzzleController
    {
        public IActionResult Generate(int knownFields);
        public IActionResult Resolve(IEnumerable<PuzzleFieldDTO> fields);
        public IActionResult GetHint(IEnumerable<PuzzleFieldDTO> fields);
    }
}
