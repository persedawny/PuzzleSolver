using Microsoft.AspNetCore.Mvc;

namespace PuzzleSolver.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PuzzleController : ControllerBase
    {
        [HttpGet]
        public void Test()
        {
            var sudoku = PuzzleMaker.GetSudokuInstance();
        }
    }
}