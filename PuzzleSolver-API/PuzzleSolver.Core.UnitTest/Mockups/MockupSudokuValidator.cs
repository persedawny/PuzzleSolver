using System;
using PuzzleSolver.Abstractions;

namespace PuzzleSolver.Core.UnitTest.Mockups
{
    internal class MockupSudokuValidator : IValidator
    {
        public InvocationService InvocationService = new InvocationService();

        public bool IsValid(string puzzleJson)
        {
            InvocationService.AddOrUpdateInvocation("IsValid");

            return true;            
        }

        public bool IsValidMove(string puzzleJson)
        {
            InvocationService.AddOrUpdateInvocation("IsValidMove");

            return true;        
        }
    }
}
