using PuzzleSolver.Abstractions;


namespace PuzzleSolver.Core
{
    internal class PuzzleServiceProvider : IPuzzleServiceProvider
    {
        public IPuzzleService GetSudokuService()
        {
            var validator = new Sudoku.Validator();
            var stackHandler = new Sudoku.StackHandler() as IStackHandler<PuzzleField>;
            return new PuzzleService(stackHandler, new Sudoku.Resolver(stackHandler), validator, new Sudoku.Generator(validator));
        }
    }
}
