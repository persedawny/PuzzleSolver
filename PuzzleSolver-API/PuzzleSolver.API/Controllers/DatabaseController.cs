using Microsoft.AspNetCore.Mvc;
using PuzzleSolver.Abstractions;
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

        [HttpPost, Route("InsertPuzzle")]
        public Task InsertPuzzleIntoDatabaseAsync([FromBody] IEnumerable<PuzzleFieldDTO> fields, PuzzleEntityType type) => repository.AddFromDtoListAsync(fields, type);
    }
}