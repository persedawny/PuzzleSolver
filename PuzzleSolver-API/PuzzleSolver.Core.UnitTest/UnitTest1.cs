using PuzzleSolver.Abstractions;
using PuzzleSolver.Core.UnitTest.Mockups;
using Xunit;

namespace PuzzleSolver.Core.UnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void FakeFirstTest()
        {
            var sudokuGenerator = new SudokuGenerator();
            PuzzleTemplate sudoku = sudokuGenerator.Generate(2);
        }
    }
}