using PuzzleSolver.Core.UnitTest.Mockups;
using System.Linq;
using Xunit;

namespace PuzzleSolver.Core.UnitTest
{
    public class SudokuTest
    {
        [Fact]
        public void Test_ResolveSudoku()
        {
            // Arrange
            var puzzleJson = "{sudoku: [" +
                "[0, 9, 4, 8, 6, 5, 2, 3, 7]," +
                "[7, 3, 5, 4, 0, 2, 9, 6, 8]," +
                "[8, 6, 2, 3, 9, 7, 1, 4, 5]," +
                "[9, 2, 0, 7, 4, 8, 3, 5, 6]," +
                "[6, 7, 8, 5, 3, 0, 4, 2, 9]," +
                "[4, 5, 3, 9, 2, 6, 8, 7, 1]," +
                "[3, 8, 9, 6, 5, 4, 7, 0, 2]," +
                "[2, 4, 6, 1, 7, 9, 5, 8, 3]," +
                "[5, 1, 7, 2, 8, 3, 6, 9, 4]" +
              "]}";

            var expected = "{sudoku: [" +
                "[1, 9, 4, 8, 6, 5, 2, 3, 7]," +
                "[7, 3, 5, 4, 1, 2, 9, 6, 8]," +
                "[8, 6, 2, 3, 9, 7, 1, 4, 5]," +
                "[9, 2, 1, 7, 4, 8, 3, 5, 6]," +
                "[6, 7, 8, 5, 3, 1, 4, 2, 9]," +
                "[4, 5, 3, 9, 2, 6, 8, 7, 1]," +
                "[3, 8, 9, 6, 5, 4, 7, 1, 2]," +
                "[2, 4, 6, 1, 7, 9, 5, 8, 3]," +
                "[5, 1, 7, 2, 8, 3, 6, 9, 4]" +
              "]}";

            var sudokuService = new MockupSudokuService();

            //Act
            var actual = sudokuService.Resolve(puzzleJson);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test_GenerateSudoku()
        {
            // Arrange
            var knownFields = 3;
            var testChar = '4';
            var sudokuService = new MockupSudokuService();

            //Act
            var generatedPuzzle = sudokuService.Generate(knownFields);
            var filledChars = generatedPuzzle.Count(c => c == testChar);

            // Assert
            Assert.Equal(knownFields, filledChars);
        }
    }
}