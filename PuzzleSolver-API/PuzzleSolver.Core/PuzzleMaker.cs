using PuzzleSolver.Core.Generators;
using PuzzleSolver.Core.Puzzles;
using PuzzleSolver.Core.Resolvers;
using PuzzleSolver.Core.Validators;

namespace PuzzleSolver.API
{
    public class PuzzleMaker
    {
        public static PuzzleController GetSudokuInstance() => new PuzzleController(new Sudoku(), new SudokuResolver(), new SudokuValidator(), new SudokuGenerator());
    }

    public enum PuzzleType
    {
        Sudoku
    }
}
