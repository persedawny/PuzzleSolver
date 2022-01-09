using Microsoft.AspNetCore.Mvc;
using PuzzleSolver.Abstractions;

namespace PuzzleSolver.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DatabaseController : Controller
    {
        private readonly IRepository<PuzzleEntity> repository;

        public DatabaseController([FromServices]IRepository<PuzzleEntity> repository)
        {
            this.repository = repository;
        }
    }
}