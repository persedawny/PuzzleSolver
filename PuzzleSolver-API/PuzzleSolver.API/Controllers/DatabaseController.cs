using Microsoft.AspNetCore.Mvc;
using PuzzleSolver.Abstractions;
using PuzzleSolver.Models.DTO;
using PuzzleSolver.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PuzzleSolver.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DatabaseController : Controller
    {
        private readonly IRepository<PuzzleEntity> repository;

        public DatabaseController([FromServices] IRepository<PuzzleEntity> repository)
        {
            this.repository = repository;
        }

        [HttpGet, Route("GetAllNames")]
        public async Task<IActionResult> GetAllNames()
        {
            return Ok(await repository.GetAllPuzzleNamesAsync());
        }

        [HttpPost, Route("InsertPuzzle")]
        public async Task<IActionResult> InsertPuzzleIntoDatabaseAsync([FromBody] IEnumerable<PuzzleFieldDTO> fields, PuzzleEntityType type)
        {
            await repository.AddFromDtoListAsync(fields, type);
            return Ok();
        }
    }
}