using PuzzleSolver.Abstractions;

namespace PuzzleSolver.Core.UnitTest.Mockups
{
    internal class MockupSudokuValidator : IValidator
    {
        public bool IsValid(string puzzleJson)
        {
            return true;            
        }

        public bool IsValidMove(string puzzleJson)
        {
            return true;        
        }
    }
}
