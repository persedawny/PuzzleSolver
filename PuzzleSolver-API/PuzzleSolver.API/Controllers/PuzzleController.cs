using Microsoft.AspNetCore.Mvc;

namespace PuzzleSolver.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PuzzleController : ControllerBase
    {
        [HttpGet]
        public ActionResult Test()
        {
            var sudoku = PuzzleMaker.GetSudokuInstance();
            return Ok(sudoku);
        }
    }
}