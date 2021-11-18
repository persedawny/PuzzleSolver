using PuzzleSolver.Abstractions;

namespace PuzzleSolver.Core.UnitTest.Mockups
{
    internal class SudokuGenerator : BaseMockup, IGenerator
    {
        public PuzzleTemplate Generate(int knownFields)
        {
            // TODO: Make a real mockup implementation
            AddOrUpdateInvocation("Generate");

            return new Sudoku();
        }
    }
}
