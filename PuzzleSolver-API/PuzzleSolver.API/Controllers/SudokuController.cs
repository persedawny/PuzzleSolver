using Microsoft.AspNetCore.Mvc;
using PuzzleSolver.Abstractions;

namespace PuzzleSolver.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SudokuController : ControllerBase, IPuzzleController
    {
        private readonly IPuzzleService controller;

        public SudokuController(PuzzleServiceFactory factory)
        {
            controller = factory.GetSudokuController();
        }
    }
}
