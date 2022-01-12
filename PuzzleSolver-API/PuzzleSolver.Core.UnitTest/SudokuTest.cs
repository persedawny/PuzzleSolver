using PuzzleSolver.Abstractions;
using PuzzleSolver.Core.UnitTest.Mockups;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Sdk;

namespace PuzzleSolver.Core.UnitTest
{
    public class SudokuTest
    {
        [Fact]
        public void Test_Resolve_Success()
        {
            // Arrange
            var puzzleFields = new List<PuzzleFieldTemplate>()
            {
                new Mockup_SudokuField(), new Mockup_SudokuField("9"), new Mockup_SudokuField("4"), new Mockup_SudokuField("8"), new Mockup_SudokuField("6"), new Mockup_SudokuField("5"), new Mockup_SudokuField("2"), new Mockup_SudokuField("3"), new Mockup_SudokuField("7"),
                new Mockup_SudokuField("7"), new Mockup_SudokuField("3"), new Mockup_SudokuField("5"), new Mockup_SudokuField("4"), new Mockup_SudokuField(), new Mockup_SudokuField("2"), new Mockup_SudokuField("9"), new Mockup_SudokuField("6"), new Mockup_SudokuField("8"),
                new Mockup_SudokuField("8"), new Mockup_SudokuField("6"), new Mockup_SudokuField("2"), new Mockup_SudokuField("3"), new Mockup_SudokuField("9"), new Mockup_SudokuField("7"), new Mockup_SudokuField("1"), new Mockup_SudokuField("4"), new Mockup_SudokuField("5"),
                new Mockup_SudokuField("9"), new Mockup_SudokuField("2"), new Mockup_SudokuField(), new Mockup_SudokuField("7"), new Mockup_SudokuField("4"), new Mockup_SudokuField("8"), new Mockup_SudokuField("3"), new Mockup_SudokuField("5"), new Mockup_SudokuField("6"),
                new Mockup_SudokuField("6"), new Mockup_SudokuField("7"), new Mockup_SudokuField("8"), new Mockup_SudokuField("5"), new Mockup_SudokuField("3"), new Mockup_SudokuField(), new Mockup_SudokuField("4"), new Mockup_SudokuField("2"), new Mockup_SudokuField("9"),
                new Mockup_SudokuField("4"), new Mockup_SudokuField("5"), new Mockup_SudokuField("3"), new Mockup_SudokuField("9"), new Mockup_SudokuField("2"), new Mockup_SudokuField("6"), new Mockup_SudokuField("8"), new Mockup_SudokuField("7"), new Mockup_SudokuField("1"),
                new Mockup_SudokuField("3"), new Mockup_SudokuField("8"), new Mockup_SudokuField("9"), new Mockup_SudokuField("6"), new Mockup_SudokuField("5"), new Mockup_SudokuField("4"), new Mockup_SudokuField("7"), new Mockup_SudokuField(), new Mockup_SudokuField("2"),
                new Mockup_SudokuField("2"), new Mockup_SudokuField("4"), new Mockup_SudokuField("6"), new Mockup_SudokuField("1"), new Mockup_SudokuField("7"), new Mockup_SudokuField("9"), new Mockup_SudokuField("5"), new Mockup_SudokuField("8"), new Mockup_SudokuField("3"),
                new Mockup_SudokuField("5"), new Mockup_SudokuField("1"), new Mockup_SudokuField("7"), new Mockup_SudokuField("2"), new Mockup_SudokuField("8"), new Mockup_SudokuField("3"), new Mockup_SudokuField("6"), new Mockup_SudokuField("9"), new Mockup_SudokuField("4"),
            };

            var expected = new List<PuzzleFieldTemplate>()
            {
                new Mockup_SudokuField("1"), new Mockup_SudokuField("9"), new Mockup_SudokuField("4"), new Mockup_SudokuField("8"), new Mockup_SudokuField("6"), new Mockup_SudokuField("5"), new Mockup_SudokuField("2"), new Mockup_SudokuField("3"), new Mockup_SudokuField("7"),
                new Mockup_SudokuField("7"), new Mockup_SudokuField("3"), new Mockup_SudokuField("5"), new Mockup_SudokuField("4"), new Mockup_SudokuField("1"), new Mockup_SudokuField("2"), new Mockup_SudokuField("9"), new Mockup_SudokuField("6"), new Mockup_SudokuField("8"),
                new Mockup_SudokuField("8"), new Mockup_SudokuField("6"), new Mockup_SudokuField("2"), new Mockup_SudokuField("3"), new Mockup_SudokuField("9"), new Mockup_SudokuField("7"), new Mockup_SudokuField("1"), new Mockup_SudokuField("4"), new Mockup_SudokuField("5"),
                new Mockup_SudokuField("9"), new Mockup_SudokuField("2"), new Mockup_SudokuField("1"), new Mockup_SudokuField("7"), new Mockup_SudokuField("4"), new Mockup_SudokuField("8"), new Mockup_SudokuField("3"), new Mockup_SudokuField("5"), new Mockup_SudokuField("6"),
                new Mockup_SudokuField("6"), new Mockup_SudokuField("7"), new Mockup_SudokuField("8"), new Mockup_SudokuField("5"), new Mockup_SudokuField("3"), new Mockup_SudokuField("1"), new Mockup_SudokuField("4"), new Mockup_SudokuField("2"), new Mockup_SudokuField("9"),
                new Mockup_SudokuField("4"), new Mockup_SudokuField("5"), new Mockup_SudokuField("3"), new Mockup_SudokuField("9"), new Mockup_SudokuField("2"), new Mockup_SudokuField("6"), new Mockup_SudokuField("8"), new Mockup_SudokuField("7"), new Mockup_SudokuField("1"),
                new Mockup_SudokuField("3"), new Mockup_SudokuField("8"), new Mockup_SudokuField("9"), new Mockup_SudokuField("6"), new Mockup_SudokuField("5"), new Mockup_SudokuField("4"), new Mockup_SudokuField("7"), new Mockup_SudokuField("1"), new Mockup_SudokuField("2"),
                new Mockup_SudokuField("2"), new Mockup_SudokuField("4"), new Mockup_SudokuField("6"), new Mockup_SudokuField("1"), new Mockup_SudokuField("7"), new Mockup_SudokuField("9"), new Mockup_SudokuField("5"), new Mockup_SudokuField("8"), new Mockup_SudokuField("3"),
                new Mockup_SudokuField("5"), new Mockup_SudokuField("1"), new Mockup_SudokuField("7"), new Mockup_SudokuField("2"), new Mockup_SudokuField("8"), new Mockup_SudokuField("3"), new Mockup_SudokuField("6"), new Mockup_SudokuField("9"), new Mockup_SudokuField("4"),
            };

            var sudokuService = new Mockup_SudokuService();


            try
            {
                //Act
                var actual = sudokuService.Resolve(puzzleFields);

                var actualIsNotTheSame = actual.fields.Select(x => valueIsTheSame(expected[actual.fields.IndexOf(x)].Value, x.Value)).Contains(false);

                // Assert
                Assert.False(actualIsNotTheSame);
            }
            catch (System.Exception)
            {
                throw new XunitException();
            }
        }

        [Fact]
        public void Test_Resolve_Fail()
        {
            // Arrange
            var puzzleFields = new List<PuzzleFieldTemplate>()
            {
                new Mockup_SudokuField("1"), new Mockup_SudokuField("9"), new Mockup_SudokuField("4"), new Mockup_SudokuField("8"), new Mockup_SudokuField("6"), new Mockup_SudokuField("5"), new Mockup_SudokuField("2"), new Mockup_SudokuField("3"), new Mockup_SudokuField("7"),
                new Mockup_SudokuField("7"), new Mockup_SudokuField("3"), new Mockup_SudokuField("5"), new Mockup_SudokuField("4"), new Mockup_SudokuField("1"), new Mockup_SudokuField("2"), new Mockup_SudokuField("9"), new Mockup_SudokuField("6"), new Mockup_SudokuField("8"),
                new Mockup_SudokuField("8"), new Mockup_SudokuField("6"), new Mockup_SudokuField("2"), new Mockup_SudokuField("3"), new Mockup_SudokuField("9"), new Mockup_SudokuField("7"), new Mockup_SudokuField("1"), new Mockup_SudokuField("4"), new Mockup_SudokuField("5"),
                new Mockup_SudokuField("9"), new Mockup_SudokuField("2"), new Mockup_SudokuField("1"), new Mockup_SudokuField("7"), new Mockup_SudokuField("4"), new Mockup_SudokuField("8"), new Mockup_SudokuField("3"), new Mockup_SudokuField("5"), new Mockup_SudokuField("6"),
                new Mockup_SudokuField("6"), new Mockup_SudokuField("7"), new Mockup_SudokuField("8"), new Mockup_SudokuField("5"), new Mockup_SudokuField("3"), new Mockup_SudokuField("1"), new Mockup_SudokuField("4"), new Mockup_SudokuField("2"), new Mockup_SudokuField("9"),
                new Mockup_SudokuField("4"), new Mockup_SudokuField("5"), new Mockup_SudokuField("3"), new Mockup_SudokuField("9"), new Mockup_SudokuField("2"), new Mockup_SudokuField("6"), new Mockup_SudokuField("8"), new Mockup_SudokuField("7"), new Mockup_SudokuField("1"),
                new Mockup_SudokuField("3"), new Mockup_SudokuField("8"), new Mockup_SudokuField("9"), new Mockup_SudokuField("6"), new Mockup_SudokuField("5"), new Mockup_SudokuField("4"), new Mockup_SudokuField("7"), new Mockup_SudokuField("1"), new Mockup_SudokuField("2"),
                new Mockup_SudokuField("2"), new Mockup_SudokuField("4"), new Mockup_SudokuField("6"), new Mockup_SudokuField("1"), new Mockup_SudokuField("7"), new Mockup_SudokuField("9"), new Mockup_SudokuField("5"), new Mockup_SudokuField("8"), new Mockup_SudokuField("3"),
                new Mockup_SudokuField("5"), new Mockup_SudokuField("1"), new Mockup_SudokuField("7"), new Mockup_SudokuField("2"), new Mockup_SudokuField("8"), new Mockup_SudokuField("3"), new Mockup_SudokuField("6"), new Mockup_SudokuField("9"), new Mockup_SudokuField("4"),
            };

            var expected = new List<PuzzleFieldTemplate>()
            {
                new Mockup_SudokuField("1"), new Mockup_SudokuField("9"), new Mockup_SudokuField("4"), new Mockup_SudokuField("8"), new Mockup_SudokuField("6"), new Mockup_SudokuField("5"), new Mockup_SudokuField("2"), new Mockup_SudokuField("3"), new Mockup_SudokuField("7"),
                new Mockup_SudokuField("7"), new Mockup_SudokuField("3"), new Mockup_SudokuField("5"), new Mockup_SudokuField("4"), new Mockup_SudokuField("1"), new Mockup_SudokuField("2"), new Mockup_SudokuField("9"), new Mockup_SudokuField("6"), new Mockup_SudokuField("8"),
                new Mockup_SudokuField("8"), new Mockup_SudokuField("6"), new Mockup_SudokuField("2"), new Mockup_SudokuField("3"), new Mockup_SudokuField("9"), new Mockup_SudokuField("7"), new Mockup_SudokuField("1"), new Mockup_SudokuField("4"), new Mockup_SudokuField("5"),
                new Mockup_SudokuField("9"), new Mockup_SudokuField("2"), new Mockup_SudokuField("1"), new Mockup_SudokuField("7"), new Mockup_SudokuField("4"), new Mockup_SudokuField("8"), new Mockup_SudokuField("3"), new Mockup_SudokuField("5"), new Mockup_SudokuField("6"),
                new Mockup_SudokuField("6"), new Mockup_SudokuField("7"), new Mockup_SudokuField("8"), new Mockup_SudokuField("5"), new Mockup_SudokuField("3"), new Mockup_SudokuField("1"), new Mockup_SudokuField("4"), new Mockup_SudokuField("2"), new Mockup_SudokuField("9"),
                new Mockup_SudokuField("4"), new Mockup_SudokuField("5"), new Mockup_SudokuField("3"), new Mockup_SudokuField("9"), new Mockup_SudokuField("2"), new Mockup_SudokuField("6"), new Mockup_SudokuField("8"), new Mockup_SudokuField("7"), new Mockup_SudokuField("1"),
                new Mockup_SudokuField("3"), new Mockup_SudokuField("8"), new Mockup_SudokuField("9"), new Mockup_SudokuField("6"), new Mockup_SudokuField("5"), new Mockup_SudokuField("4"), new Mockup_SudokuField("7"), new Mockup_SudokuField("1"), new Mockup_SudokuField("2"),
                new Mockup_SudokuField("2"), new Mockup_SudokuField("4"), new Mockup_SudokuField("6"), new Mockup_SudokuField("1"), new Mockup_SudokuField("7"), new Mockup_SudokuField("9"), new Mockup_SudokuField("5"), new Mockup_SudokuField("8"), new Mockup_SudokuField("3"),
                new Mockup_SudokuField("5"), new Mockup_SudokuField("1"), new Mockup_SudokuField("7"), new Mockup_SudokuField("2"), new Mockup_SudokuField("8"), new Mockup_SudokuField("3"), new Mockup_SudokuField("6"), new Mockup_SudokuField("9"), new Mockup_SudokuField("4"),
            };

            var sudokuService = new Mockup_SudokuService();

            try
            {
                //Act
                var actual = sudokuService.Resolve(puzzleFields);

                var actualIsNotTheSame = actual.fields.Select(x => valueIsTheSame(expected[actual.fields.IndexOf(x)].Value, x.Value)).Contains(false);

                // TODO: Unit test afmaken met assert throw NoEmptyFields
            }
            catch (System.Exception)
            {
                throw new XunitException();
            }
        }

        [Fact]
        public void Test_GenerateSudoku()
        {
            // Arrange
            var knownFields = 3;
            var sudokuService = new Mockup_SudokuService();

            //Act
            var generatedPuzzle = sudokuService.Generate(knownFields);
            var filledChars = generatedPuzzle.fields.Count(c => string.IsNullOrEmpty(c.Value) == false);

            // Assert
            Assert.Equal(knownFields, filledChars);
        }

        public void Test_GetHint()
        {
            // Arrange
            var puzzleFields = new List<PuzzleFieldTemplate>()
            {
                new Mockup_SudokuField(), new Mockup_SudokuField("9"), new Mockup_SudokuField("4"), new Mockup_SudokuField("8"), new Mockup_SudokuField("6"), new Mockup_SudokuField("5"), new Mockup_SudokuField("2"), new Mockup_SudokuField("3"), new Mockup_SudokuField("7"),
                new Mockup_SudokuField("7"), new Mockup_SudokuField("3"), new Mockup_SudokuField("5"), new Mockup_SudokuField("4"), new Mockup_SudokuField(), new Mockup_SudokuField("2"), new Mockup_SudokuField("9"), new Mockup_SudokuField("6"), new Mockup_SudokuField("8"),
                new Mockup_SudokuField("8"), new Mockup_SudokuField("6"), new Mockup_SudokuField("2"), new Mockup_SudokuField("3"), new Mockup_SudokuField("9"), new Mockup_SudokuField("7"), new Mockup_SudokuField("1"), new Mockup_SudokuField("4"), new Mockup_SudokuField("5"),
                new Mockup_SudokuField("9"), new Mockup_SudokuField("2"), new Mockup_SudokuField(), new Mockup_SudokuField("7"), new Mockup_SudokuField("4"), new Mockup_SudokuField("8"), new Mockup_SudokuField("3"), new Mockup_SudokuField("5"), new Mockup_SudokuField("6"),
                new Mockup_SudokuField("6"), new Mockup_SudokuField("7"), new Mockup_SudokuField("8"), new Mockup_SudokuField("5"), new Mockup_SudokuField("3"), new Mockup_SudokuField(), new Mockup_SudokuField("4"), new Mockup_SudokuField("2"), new Mockup_SudokuField("9"),
                new Mockup_SudokuField("4"), new Mockup_SudokuField("5"), new Mockup_SudokuField("3"), new Mockup_SudokuField("9"), new Mockup_SudokuField("2"), new Mockup_SudokuField("6"), new Mockup_SudokuField("8"), new Mockup_SudokuField("7"), new Mockup_SudokuField("1"),
                new Mockup_SudokuField("3"), new Mockup_SudokuField("8"), new Mockup_SudokuField("9"), new Mockup_SudokuField("6"), new Mockup_SudokuField("5"), new Mockup_SudokuField("4"), new Mockup_SudokuField("7"), new Mockup_SudokuField(), new Mockup_SudokuField("2"),
                new Mockup_SudokuField("2"), new Mockup_SudokuField("4"), new Mockup_SudokuField("6"), new Mockup_SudokuField("1"), new Mockup_SudokuField("7"), new Mockup_SudokuField("9"), new Mockup_SudokuField("5"), new Mockup_SudokuField("8"), new Mockup_SudokuField("3"),
                new Mockup_SudokuField("5"), new Mockup_SudokuField("1"), new Mockup_SudokuField("7"), new Mockup_SudokuField("2"), new Mockup_SudokuField("8"), new Mockup_SudokuField("3"), new Mockup_SudokuField("6"), new Mockup_SudokuField("9"), new Mockup_SudokuField("4"),
            };

            // TODO: Get hints
        }

        [Fact]
        public void Test_GetHint_Fail()
        {
            // Arrange
            var puzzleFields = new List<PuzzleFieldTemplate>()
            {
                new Mockup_SudokuField("1"), new Mockup_SudokuField("9"), new Mockup_SudokuField("4"), new Mockup_SudokuField("8"), new Mockup_SudokuField("6"), new Mockup_SudokuField("5"), new Mockup_SudokuField("2"), new Mockup_SudokuField("3"), new Mockup_SudokuField("7"),
                new Mockup_SudokuField("7"), new Mockup_SudokuField("3"), new Mockup_SudokuField("5"), new Mockup_SudokuField("4"), new Mockup_SudokuField("1"), new Mockup_SudokuField("2"), new Mockup_SudokuField("9"), new Mockup_SudokuField("6"), new Mockup_SudokuField("8"),
                new Mockup_SudokuField("8"), new Mockup_SudokuField("6"), new Mockup_SudokuField("2"), new Mockup_SudokuField("3"), new Mockup_SudokuField("9"), new Mockup_SudokuField("7"), new Mockup_SudokuField("1"), new Mockup_SudokuField("4"), new Mockup_SudokuField("5"),
                new Mockup_SudokuField("9"), new Mockup_SudokuField("2"), new Mockup_SudokuField("1"), new Mockup_SudokuField("7"), new Mockup_SudokuField("4"), new Mockup_SudokuField("8"), new Mockup_SudokuField("3"), new Mockup_SudokuField("5"), new Mockup_SudokuField("6"),
                new Mockup_SudokuField("6"), new Mockup_SudokuField("7"), new Mockup_SudokuField("8"), new Mockup_SudokuField("5"), new Mockup_SudokuField("3"), new Mockup_SudokuField("1"), new Mockup_SudokuField("4"), new Mockup_SudokuField("2"), new Mockup_SudokuField("9"),
                new Mockup_SudokuField("4"), new Mockup_SudokuField("5"), new Mockup_SudokuField("3"), new Mockup_SudokuField("9"), new Mockup_SudokuField("2"), new Mockup_SudokuField("6"), new Mockup_SudokuField("8"), new Mockup_SudokuField("7"), new Mockup_SudokuField("1"),
                new Mockup_SudokuField("3"), new Mockup_SudokuField("8"), new Mockup_SudokuField("9"), new Mockup_SudokuField("6"), new Mockup_SudokuField("5"), new Mockup_SudokuField("4"), new Mockup_SudokuField("7"), new Mockup_SudokuField("1"), new Mockup_SudokuField("2"),
                new Mockup_SudokuField("2"), new Mockup_SudokuField("4"), new Mockup_SudokuField("6"), new Mockup_SudokuField("1"), new Mockup_SudokuField("7"), new Mockup_SudokuField("9"), new Mockup_SudokuField("5"), new Mockup_SudokuField("8"), new Mockup_SudokuField("3"),
                new Mockup_SudokuField("5"), new Mockup_SudokuField("1"), new Mockup_SudokuField("7"), new Mockup_SudokuField("2"), new Mockup_SudokuField("8"), new Mockup_SudokuField("3"), new Mockup_SudokuField("6"), new Mockup_SudokuField("9"), new Mockup_SudokuField("4"),
            };

            // TODO: Assert throw no empty field
        }

        private bool valueIsTheSame(string expected, string actual) => expected == actual;
    }
}