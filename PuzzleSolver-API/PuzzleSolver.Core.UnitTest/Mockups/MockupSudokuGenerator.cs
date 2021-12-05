using PuzzleSolver.Abstractions;
using System;

namespace PuzzleSolver.Core.UnitTest.Mockups
{
    internal class MockupSudokuGenerator : GeneratorTemplate
    {
        public InvocationService InvocationService = new InvocationService();

        public MockupSudokuGenerator(MockupSudokuValidator sudokuValidator) : base(sudokuValidator) { }

        public override PuzzleTemplate Generate(int knownFields)
        {
            InvocationService.AddOrUpdateInvocation("Generate");

           // TODO Fix test, ik kan atm ook niet bij SudokuTemplate
        }
    }
}
