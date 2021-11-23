using PuzzleSolver.Abstractions;
using PuzzleSolver.Core.Generators;
using PuzzleSolver.Core.Resolvers;
using PuzzleSolver.Core.Validators;

namespace PuzzleSolver.Core
{
    public class PuzzleServiceFactory
    {
        public static IPuzzleService GetSudokuService()
        {
            var validator = new SudokuValidator();
            return new PuzzleService(new SudokuResolver(validator), validator, new SudokuGenerator(validator));
        }
    }
}
