using PuzzleSolver.Abstractions;
using PuzzleSolver.DB;

namespace PuzzleSolver.Core
{
    public class PuzzleServiceFactory
    {
        public static IPuzzleService GetSudokuService()
        {
            var validator = new Sudoku.Validator();
            var stackHandler = new Sudoku.StackHandler() as IStackHandler<PuzzleField>;
            return new PuzzleService(RepositoryFactory.GetPuzzleRepository(), stackHandler, new Sudoku.Resolver(stackHandler), validator, new Sudoku.Generator(validator));
        }
    }
}
