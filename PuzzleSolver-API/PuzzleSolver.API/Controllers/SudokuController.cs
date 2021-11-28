using Microsoft.AspNetCore.Mvc;
using PuzzleSolver.Abstractions;
using PuzzleSolver.Core;

namespace PuzzleSolver.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SudokuController : ControllerBase, IPuzzleController
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
        public PuzzleTemplate Generate(int knownFields)
        {
            // TODO: Implement after unit tests
            return service.Generate(knownFields);
        }

        public string Resolve(string puzzleJson) => service.Resolve(puzzleJson);
    }
}