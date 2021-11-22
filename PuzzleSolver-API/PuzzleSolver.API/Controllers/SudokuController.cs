using Microsoft.AspNetCore.Mvc;
using PuzzleSolver.Abstractions;
using PuzzleSolver.Core;

namespace PuzzleSolver.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SudokuController : ControllerBase, IPuzzleController
    {
        private readonly IPuzzleService controller;

        public SudokuController(PuzzleServiceFactory factory)
        {
            controller = PuzzleServiceFactory.GetSudokuController();
        }

        [HttpPost]
        public bool CheckState(string puzzleJson)
        {
            // TODO: Implement after unit tests
            return controller.CheckState(puzzleJson);
        }

        [HttpGet]
        public PuzzleTemplate Generate(int difficulty)
        {
            // TODO: Implement after unit tests
            return controller.Generate(difficulty);
        }
    }
}