using PuzzleSolver.Abstractions;

namespace PuzzleSolver.Core
{
    public class PuzzleServiceFactory
    {
        public static IPuzzleService GetSudokuService()
        {
            var validator = new Sudoku.Validator();
            return new PuzzleService(new Sudoku.Resolver(), validator, new Sudoku.Generator(validator));
        }
    }
}
