using PuzzleSolver.Abstractions;
using System.Collections.Generic;

namespace PuzzleSolver.Core.UnitTest.Mockups
{
    internal class MockupSudokuGenerator : GeneratorTemplate
    {
        public InvocationService InvocationService = new InvocationService();

        public MockupSudokuGenerator(MockupSudokuValidator sudokuValidator) : base(sudokuValidator) { }

        public override PuzzleTemplate Generate(int knownFields)
        {
            InvocationService.AddOrUpdateInvocation("Generate");

            return new Sudoku(new List<PuzzleField>());
        }
    }
}
