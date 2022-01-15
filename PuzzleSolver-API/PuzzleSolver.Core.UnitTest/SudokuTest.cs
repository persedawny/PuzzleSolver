using PuzzleSolver.Abstractions;
using PuzzleSolver.Core.UnitTest.Mockups;
using PuzzleSolver.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

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

            // Act
            var actual = sudokuService.Resolve(puzzleFields);

            var actualIsNotTheSame = actual.Fields.Select(x => valueIsTheSame(expected[actual.Fields.IndexOf(x)].Value, x.Value)).Contains(false);

            // Assert
            Assert.False(actualIsNotTheSame);
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

            var sudokuService = new Mockup_SudokuService();

            // Act
            Action act = () => sudokuService.Resolve(puzzleFields);

            // Assert
            Assert.Throws<Exception>(act);
        }

        [Fact]
        public void Test_GenerateSudoku()
        {
            // Arrange
            var knownFields = 3;
            var sudokuService = new Mockup_SudokuService();

            //Act
            var generatedPuzzle = sudokuService.Generate(knownFields);
            var filledChars = generatedPuzzle.Fields.Count(c => string.IsNullOrEmpty(c.Value) == false);

            // Assert
            Assert.Equal(knownFields, filledChars);
        }

        [Fact]
        public void Test_GetHint()
        {
            // Arrange
            var puzzleFields = new List<PuzzleFieldDTO>()
            {
                new Mockup_SudokuField().ToDTO(), new Mockup_SudokuField("9").ToDTO(), new Mockup_SudokuField("4").ToDTO(), new Mockup_SudokuField("8").ToDTO(), new Mockup_SudokuField("6").ToDTO(), new Mockup_SudokuField("5").ToDTO(), new Mockup_SudokuField("2").ToDTO(), new Mockup_SudokuField("3").ToDTO(), new Mockup_SudokuField("7").ToDTO(),
                new Mockup_SudokuField("7").ToDTO(), new Mockup_SudokuField("3").ToDTO(), new Mockup_SudokuField("5").ToDTO(), new Mockup_SudokuField("4").ToDTO(), new Mockup_SudokuField().ToDTO(), new Mockup_SudokuField("2").ToDTO(), new Mockup_SudokuField("9").ToDTO(), new Mockup_SudokuField("6").ToDTO(), new Mockup_SudokuField("8").ToDTO(),
                new Mockup_SudokuField("8").ToDTO(), new Mockup_SudokuField("6").ToDTO(), new Mockup_SudokuField("2").ToDTO(), new Mockup_SudokuField("3").ToDTO(), new Mockup_SudokuField("9").ToDTO(), new Mockup_SudokuField("7").ToDTO(), new Mockup_SudokuField("1").ToDTO(), new Mockup_SudokuField("4").ToDTO(), new Mockup_SudokuField("5").ToDTO(),
                new Mockup_SudokuField("9").ToDTO(), new Mockup_SudokuField("2").ToDTO(), new Mockup_SudokuField().ToDTO(), new Mockup_SudokuField("7").ToDTO(), new Mockup_SudokuField("4").ToDTO(), new Mockup_SudokuField("8").ToDTO(), new Mockup_SudokuField("3").ToDTO(), new Mockup_SudokuField("5").ToDTO(), new Mockup_SudokuField("6").ToDTO(),
                new Mockup_SudokuField("6").ToDTO(), new Mockup_SudokuField("7").ToDTO(), new Mockup_SudokuField("8").ToDTO(), new Mockup_SudokuField("5").ToDTO(), new Mockup_SudokuField("3").ToDTO(), new Mockup_SudokuField().ToDTO(), new Mockup_SudokuField("4").ToDTO(), new Mockup_SudokuField("2").ToDTO(), new Mockup_SudokuField("9").ToDTO(),
                new Mockup_SudokuField("4").ToDTO(), new Mockup_SudokuField("5").ToDTO(), new Mockup_SudokuField("3").ToDTO(), new Mockup_SudokuField("9").ToDTO(), new Mockup_SudokuField("2").ToDTO(), new Mockup_SudokuField("6").ToDTO(), new Mockup_SudokuField("8").ToDTO(), new Mockup_SudokuField("7").ToDTO(), new Mockup_SudokuField("1").ToDTO(),
                new Mockup_SudokuField("3").ToDTO(), new Mockup_SudokuField("8").ToDTO(), new Mockup_SudokuField("9").ToDTO(), new Mockup_SudokuField("6").ToDTO(), new Mockup_SudokuField("5").ToDTO(), new Mockup_SudokuField("4").ToDTO(), new Mockup_SudokuField("7").ToDTO(), new Mockup_SudokuField().ToDTO(), new Mockup_SudokuField("2").ToDTO(),
                new Mockup_SudokuField("2").ToDTO(), new Mockup_SudokuField("4").ToDTO(), new Mockup_SudokuField("6").ToDTO(), new Mockup_SudokuField("1").ToDTO(), new Mockup_SudokuField("7").ToDTO(), new Mockup_SudokuField("9").ToDTO(), new Mockup_SudokuField("5").ToDTO(), new Mockup_SudokuField("8").ToDTO(), new Mockup_SudokuField("3").ToDTO(),
                new Mockup_SudokuField("5").ToDTO(), new Mockup_SudokuField("1").ToDTO(), new Mockup_SudokuField("7").ToDTO(), new Mockup_SudokuField("2").ToDTO(), new Mockup_SudokuField("8").ToDTO(), new Mockup_SudokuField("3").ToDTO(), new Mockup_SudokuField("6").ToDTO(), new Mockup_SudokuField("9").ToDTO(), new Mockup_SudokuField("4").ToDTO(),
            };

            var sudokuService = new Mockup_SudokuService();

            // Act
            var hints = sudokuService.GetHint(puzzleFields);

            Assert.True(hints.First() == "1");
        }

        [Fact]
        public void Test_GetHint_Fail()
        {
            // Arrange
            var puzzleFields = new List<PuzzleFieldDTO>()
            {
                new Mockup_SudokuField("1").ToDTO(), new Mockup_SudokuField("9").ToDTO(), new Mockup_SudokuField("4").ToDTO(), new Mockup_SudokuField("8").ToDTO(), new Mockup_SudokuField("6").ToDTO(), new Mockup_SudokuField("5").ToDTO(), new Mockup_SudokuField("2").ToDTO(), new Mockup_SudokuField("3").ToDTO(), new Mockup_SudokuField("7").ToDTO(),
                new Mockup_SudokuField("7").ToDTO(), new Mockup_SudokuField("3").ToDTO(), new Mockup_SudokuField("5").ToDTO(), new Mockup_SudokuField("4").ToDTO(), new Mockup_SudokuField("1").ToDTO(), new Mockup_SudokuField("2").ToDTO(), new Mockup_SudokuField("9").ToDTO(), new Mockup_SudokuField("6").ToDTO(), new Mockup_SudokuField("8").ToDTO(),
                new Mockup_SudokuField("8").ToDTO(), new Mockup_SudokuField("6").ToDTO(), new Mockup_SudokuField("2").ToDTO(), new Mockup_SudokuField("3").ToDTO(), new Mockup_SudokuField("9").ToDTO(), new Mockup_SudokuField("7").ToDTO(), new Mockup_SudokuField("1").ToDTO(), new Mockup_SudokuField("4").ToDTO(), new Mockup_SudokuField("5").ToDTO(),
                new Mockup_SudokuField("9").ToDTO(), new Mockup_SudokuField("2").ToDTO(), new Mockup_SudokuField("1").ToDTO(), new Mockup_SudokuField("7").ToDTO(), new Mockup_SudokuField("4").ToDTO(), new Mockup_SudokuField("8").ToDTO(), new Mockup_SudokuField("3").ToDTO(), new Mockup_SudokuField("5").ToDTO(), new Mockup_SudokuField("6").ToDTO(),
                new Mockup_SudokuField("6").ToDTO(), new Mockup_SudokuField("7").ToDTO(), new Mockup_SudokuField("8").ToDTO(), new Mockup_SudokuField("5").ToDTO(), new Mockup_SudokuField("3").ToDTO(), new Mockup_SudokuField("1").ToDTO(), new Mockup_SudokuField("4").ToDTO(), new Mockup_SudokuField("2").ToDTO(), new Mockup_SudokuField("9").ToDTO(),
                new Mockup_SudokuField("4").ToDTO(), new Mockup_SudokuField("5").ToDTO(), new Mockup_SudokuField("3").ToDTO(), new Mockup_SudokuField("9").ToDTO(), new Mockup_SudokuField("2").ToDTO(), new Mockup_SudokuField("6").ToDTO(), new Mockup_SudokuField("8").ToDTO(), new Mockup_SudokuField("7").ToDTO(), new Mockup_SudokuField("1").ToDTO(),
                new Mockup_SudokuField("3").ToDTO(), new Mockup_SudokuField("8").ToDTO(), new Mockup_SudokuField("9").ToDTO(), new Mockup_SudokuField("6").ToDTO(), new Mockup_SudokuField("5").ToDTO(), new Mockup_SudokuField("4").ToDTO(), new Mockup_SudokuField("7").ToDTO(), new Mockup_SudokuField("1").ToDTO(), new Mockup_SudokuField("2").ToDTO(),
                new Mockup_SudokuField("2").ToDTO(), new Mockup_SudokuField("4").ToDTO(), new Mockup_SudokuField("6").ToDTO(), new Mockup_SudokuField("1").ToDTO(), new Mockup_SudokuField("7").ToDTO(), new Mockup_SudokuField("9").ToDTO(), new Mockup_SudokuField("5").ToDTO(), new Mockup_SudokuField("8").ToDTO(), new Mockup_SudokuField("3").ToDTO(),
                new Mockup_SudokuField("5").ToDTO(), new Mockup_SudokuField("1").ToDTO(), new Mockup_SudokuField("7").ToDTO(), new Mockup_SudokuField("2").ToDTO(), new Mockup_SudokuField("8").ToDTO(), new Mockup_SudokuField("3").ToDTO(), new Mockup_SudokuField("6").ToDTO(), new Mockup_SudokuField("9").ToDTO(), new Mockup_SudokuField("4").ToDTO(),
            };

            var sudokuService = new Mockup_SudokuService();

            // Act
            Action act = () => sudokuService.GetHint(puzzleFields);

            // Assert
            Assert.Throws<Exception>(act);
        }

        private bool valueIsTheSame(string expected, string actual) => expected == actual;
    }
}