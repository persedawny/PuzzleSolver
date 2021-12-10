using PuzzleSolver.Abstractions;

namespace PuzzleSolver.Core
{
    public class PuzzleServiceFactory
    {
        public static IPuzzleService GetSudokuService()
        {
            var validator = new Sudoku.Validator();
            var stackHandler = new Sudoku.StackHandler();
            return new PuzzleService(stackHandler, new Sudoku.Resolver(stackHandler), validator, new Sudoku.Generator(validator));
        }
    }
}
