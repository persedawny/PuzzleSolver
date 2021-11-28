using Microsoft.AspNetCore.Mvc;
using PuzzleSolver.Abstractions;
using PuzzleSolver.Core;

namespace PuzzleSolver.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SudokuController : ControllerBase//, //IPuzzleController
    {
        private readonly IPuzzleService service;

        public SudokuController()
        {
            service = PuzzleServiceFactory.GetSudokuService();
        }

        [HttpPost]
        public bool CheckState(string puzzleJson)
        {
            // TODO: Implement after unit tests
            return service.CheckState(puzzleJson);
        }

        [HttpGet]
        public string Generate(int knownFields)
        {
            var puzzle = service.Generate(knownFields);
            var isPuzzleValid = false;
            while (!isPuzzleValid) {
                try
                {
                    service.Resolve(puzzle);
                    isPuzzleValid = true;

                }
                catch {}
            }
            return puzzle;
        }

        [HttpGet]
        public string Resolve(string puzzleJson) => service.Resolve(puzzleJson);
    }
}