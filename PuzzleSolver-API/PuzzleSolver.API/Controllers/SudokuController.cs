using Microsoft.AspNetCore.Mvc;
using PuzzleSolver.Abstractions;
using PuzzleSolver.Models.DTO;
using System.Collections.Generic;
using System.Linq;

namespace PuzzleSolver.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SudokuController : Controller, IPuzzleController
    {
        private readonly IPuzzleService service;

        public SudokuController([FromServices] IPuzzleServiceProvider serviceProvider)
        {
            service = serviceProvider.GetSudokuService();
        }

        [HttpGet, Route("Generate")]
        public IActionResult Generate(int knownFields)
        {
            return Ok(service.Generate(knownFields).GetContentAsJson());
        }

        [HttpPost, Route("GetHint")]
        public IActionResult GetHint(IEnumerable<PuzzleFieldDTO> fields)
        {
            return Ok(service.GetHint(fields));
        }

        [HttpPost, Route("Resolve")]
        public IActionResult Resolve([FromBody] IEnumerable<PuzzleFieldDTO> fields)
        {
            var puzzle = service.Resolve(fields);
            return Ok(puzzle.Fields.Select(x => new PuzzleFieldDTO() { Value = x.Value }).ToList());
        }
    }
}