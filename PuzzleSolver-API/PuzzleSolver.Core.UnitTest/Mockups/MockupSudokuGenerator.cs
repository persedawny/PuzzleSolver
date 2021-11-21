using PuzzleSolver.Abstractions;
using System;

namespace PuzzleSolver.Core.UnitTest.Mockups
{
    internal class MockupSudokuGenerator : GeneratorTemplate
    {
        public MockupSudokuGenerator(MockupSudokuValidator sudokuValidator) : base(sudokuValidator) { }

        public override PuzzleTemplate Generate(int knownFields)
        {
            throw new NotImplementedException();
        }
    }
}
