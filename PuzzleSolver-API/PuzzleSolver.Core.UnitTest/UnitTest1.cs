using PuzzleSolver.Core.UnitTest.Mockups;
using Xunit;

namespace PuzzleSolver.Core.UnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test_ResolveSudoku()
        {
            var puzzleJson = "";
            var sudokuService = new MockupSudokuService();
            sudokuService.Resolve(puzzleJson);
        }
    }
}