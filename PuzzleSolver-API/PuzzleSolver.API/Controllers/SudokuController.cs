using Microsoft.AspNetCore.Mvc;
using PuzzleSolver.Abstractions;
using PuzzleSolver.Core;
using System.Collections.Generic;

namespace PuzzleSolver.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SudokuController : Controller, IPuzzleController
    {
        private readonly IPuzzleService service;

        public SudokuController()
        {
            service = PuzzleServiceFactory.GetSudokuService();
        }

        [HttpPost, Route("CheckState")]
        public IActionResult CheckState(PuzzleTemplate puzzle)
        {
            // TODO: Implement after unit tests
            return Ok(service.CheckState(puzzle));
        }

        [HttpGet, Route("Generate")]
        public IActionResult Generate(int knownFields)
        {
            // TODO: Domain logica, niet in de api controllers (Paul)
            var puzzle = service.Generate(knownFields);
            var isPuzzleValid = false;

            while (!isPuzzleValid)
            {
                service.Resolve(puzzle.fields);
                isPuzzleValid = true;
            }

            return Ok(puzzle.GetContentAsJson());
        }

        [HttpPost, Route("Resolve")]
        public IActionResult Resolve([FromBody] List<PuzzleField> fields)
        {
            var puzzle = service.Resolve(fields);
            return Ok(puzzle.fields);
        }
    }
}