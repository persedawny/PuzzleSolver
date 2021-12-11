using PuzzleSolver.Abstractions;

namespace PuzzleSolver.Core
{
    public class PuzzleServiceFactory
    {
        public static IPuzzleService GetSudokuService()
        {
            var mapper = new Sudoku.FieldMapper();
            var validator = new Sudoku.Validator(mapper);
            var stackHandler = new Sudoku.StackHandler();
            return new PuzzleService(stackHandler, new Sudoku.Resolver(stackHandler, mapper), validator, new Sudoku.Generator(validator));
        }
    }
}
