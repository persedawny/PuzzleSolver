using Microsoft.AspNetCore.Mvc;
using PuzzleSolver.Abstractions;
using PuzzleSolver.Core;
using System.Collections.Generic;

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

        [HttpPost, Route("CheckState")]
        public bool CheckState(PuzzleTemplate puzzle)
        {
            // TODO: Implement after unit tests
            return service.CheckState(puzzle);
        }

        [HttpGet, Route("Generate"), Produces("application/json")]
        public string Generate(int knownFields)
        {
            // TODO: Domain logica, niet in de api controllers (Paul)
            var puzzle = service.Generate(knownFields);
            var isPuzzleValid = false;
            while (!isPuzzleValid) {
                try
                {
                    service.Resolve(puzzle.fields);
                    isPuzzleValid = true;

                }
                catch {}
            }
            return puzzle.GetContentAsJson();
        }

        [HttpPost, Route("Resolve")]
        public IActionResult Resolve([FromBody]List<PuzzleField> fields) => Ok(service.Resolve(fields));
    }
}