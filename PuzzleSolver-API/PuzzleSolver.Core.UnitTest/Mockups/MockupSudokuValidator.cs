using PuzzleSolver.Abstractions;
using System.Collections.Generic;

namespace PuzzleSolver.Core.UnitTest.Mockups
{
    internal class MockupSudokuValidator : IValidator
    {
        public InvocationService InvocationService = new InvocationService();

        public bool IsValid(List<PuzzleField> fields)
        {
            InvocationService.AddOrUpdateInvocation("IsValid");
            return true;
        }
    }
}
