using PuzzleSolver.Abstractions;
using System.Collections.Generic;

namespace PuzzleSolver.Core.UnitTest.Mockups
{
    internal class Mockup_SudokuValidator : IValidator
    {
        public InvocationService InvocationService = new InvocationService();

        public bool IsValid(List<PuzzleFieldTemplate> fields)
        {
            InvocationService.AddOrUpdateInvocation("IsValid");
            return true;
        }
    }
}
