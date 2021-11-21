using PuzzleSolver.Abstractions;
using PuzzleSolver.Core.Generators;
using PuzzleSolver.Core.Resolvers;
using PuzzleSolver.Core.Validators;

namespace PuzzleSolver.API
{
    public class PuzzleServiceFactory
    {
        public IPuzzleService GetSudokuController() => new PuzzleService(new SudokuResolver(), new SudokuValidator(), new SudokuGenerator());
    }
}
