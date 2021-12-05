using System;
using PuzzleSolver.Abstractions;

namespace PuzzleSolver.Core.UnitTest.Mockups
{
    internal class MockupSudokuValidator : IValidator
    {
        public InvocationService InvocationService = new InvocationService();

        public bool IsValid(PuzzleTemplate puzzleJson)
        {
            InvocationService.AddOrUpdateInvocation("IsValid");

            return true;            
        }

        public bool IsValidMove(PuzzleTemplate puzzleJson)
        {
            InvocationService.AddOrUpdateInvocation("IsValidMove");

            return true;        
        }
    }
}
