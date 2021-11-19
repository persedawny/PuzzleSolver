using PuzzleSolver.Abstractions;
using PuzzleSolver.Core.Generators;
using PuzzleSolver.Core.Resolvers;
using PuzzleSolver.Core.Validators;

namespace PuzzleSolver.API
{
    public class PuzzleControllerFactory
    {
        public static IPuzzleController GetSudokuController() => new PuzzleController(new SudokuResolver(), new SudokuValidator(), new SudokuGenerator());
    }
}
