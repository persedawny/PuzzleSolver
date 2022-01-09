using PuzzleSolver.Abstractions;
using PuzzleSolver.Core.UnitTest.Mockups;
using System.Collections.Generic;
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
            var puzzleFields = new List<PuzzleField>()
            {
                new SudokuField(), new SudokuField("9"), new SudokuField("4"), new SudokuField("8"), new SudokuField("6"), new SudokuField("5"), new SudokuField("2"), new SudokuField("3"), new SudokuField("7"),
                new SudokuField("7"), new SudokuField("3"), new SudokuField("5"), new SudokuField("4"), new SudokuField(), new SudokuField("2"), new SudokuField("9"), new SudokuField("6"), new SudokuField("8"),
                new SudokuField("8"), new SudokuField("6"), new SudokuField("2"), new SudokuField("3"), new SudokuField("9"), new SudokuField("7"), new SudokuField("1"), new SudokuField("4"), new SudokuField("5"),
                new SudokuField("9"), new SudokuField("2"), new SudokuField(), new SudokuField("7"), new SudokuField("4"), new SudokuField("8"), new SudokuField("3"), new SudokuField("5"), new SudokuField("6"),
                new SudokuField("6"), new SudokuField("7"), new SudokuField("8"), new SudokuField("5"), new SudokuField("3"), new SudokuField(), new SudokuField("4"), new SudokuField("2"), new SudokuField("9"),
                new SudokuField("4"), new SudokuField("5"), new SudokuField("3"), new SudokuField("9"), new SudokuField("2"), new SudokuField("6"), new SudokuField("8"), new SudokuField("7"), new SudokuField("1"),
                new SudokuField("3"), new SudokuField("8"), new SudokuField("9"), new SudokuField("6"), new SudokuField("5"), new SudokuField("4"), new SudokuField("7"), new SudokuField(), new SudokuField("2"),
                new SudokuField("2"), new SudokuField("4"), new SudokuField("6"), new SudokuField("1"), new SudokuField("7"), new SudokuField("9"), new SudokuField("5"), new SudokuField("8"), new SudokuField("3"),
                new SudokuField("5"), new SudokuField("1"), new SudokuField("7"), new SudokuField("2"), new SudokuField("8"), new SudokuField("3"), new SudokuField("6"), new SudokuField("9"), new SudokuField("4"),

            };

            var expected = new List<PuzzleField>()
            {
                new SudokuField("1"), new SudokuField("9"), new SudokuField("4"), new SudokuField("8"), new SudokuField("6"), new SudokuField("5"), new SudokuField("2"), new SudokuField("3"), new SudokuField("7"),
                new SudokuField("7"), new SudokuField("3"), new SudokuField("5"), new SudokuField("4"), new SudokuField("1"), new SudokuField("2"), new SudokuField("9"), new SudokuField("6"), new SudokuField("8"),
                new SudokuField("8"), new SudokuField("6"), new SudokuField("2"), new SudokuField("3"), new SudokuField("9"), new SudokuField("7"), new SudokuField("1"), new SudokuField("4"), new SudokuField("5"),
                new SudokuField("9"), new SudokuField("2"), new SudokuField("1"), new SudokuField("7"), new SudokuField("4"), new SudokuField("8"), new SudokuField("3"), new SudokuField("5"), new SudokuField("6"),
                new SudokuField("6"), new SudokuField("7"), new SudokuField("8"), new SudokuField("5"), new SudokuField("3"), new SudokuField("1"), new SudokuField("4"), new SudokuField("2"), new SudokuField("9"),
                new SudokuField("4"), new SudokuField("5"), new SudokuField("3"), new SudokuField("9"), new SudokuField("2"), new SudokuField("6"), new SudokuField("8"), new SudokuField("7"), new SudokuField("1"),
                new SudokuField("3"), new SudokuField("8"), new SudokuField("9"), new SudokuField("6"), new SudokuField("5"), new SudokuField("4"), new SudokuField("7"), new SudokuField("1"), new SudokuField("2"),
                new SudokuField("2"), new SudokuField("4"), new SudokuField("6"), new SudokuField("1"), new SudokuField("7"), new SudokuField("9"), new SudokuField("5"), new SudokuField("8"), new SudokuField("3"),
                new SudokuField("5"), new SudokuField("1"), new SudokuField("7"), new SudokuField("2"), new SudokuField("8"), new SudokuField("3"), new SudokuField("6"), new SudokuField("9"), new SudokuField("4"),
            };

            var sudokuService = new MockupSudokuService();

            //Act
            var actual = sudokuService.Resolve(puzzleFields);

            var actualIsNotTheSame = actual.fields.Select(x => valueIsTheSame(expected[actual.fields.IndexOf(x)].Value, x.Value)).Contains(false);

            // Assert
            Assert.False(actualIsNotTheSame);
        }

        [Fact]
        public void Test_GenerateSudoku()
        {
            // Arrange
            var knownFields = 3;
            var sudokuService = new MockupSudokuService();

            //Act
            var generatedPuzzle = sudokuService.Generate(knownFields);
            var filledChars = generatedPuzzle.fields.Count(c => string.IsNullOrEmpty(c.Value) == false);

            // Assert
            Assert.Equal(knownFields, filledChars);
        }

        private bool valueIsTheSame(string expected, string actual) => expected == actual;
    }
}