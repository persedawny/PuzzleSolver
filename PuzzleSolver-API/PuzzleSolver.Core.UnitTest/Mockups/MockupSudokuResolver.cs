using PuzzleSolver.Abstractions;
using System.Collections.Generic;

namespace PuzzleSolver.Core.UnitTest.Mockups
{
    internal class MockupSudokuResolver : ResolverTemplate
    {
        public InvocationService InvocationService = new InvocationService();
            
        public override bool IsResolved(PuzzleTemplate puzzle)
        {
            InvocationService.AddOrUpdateInvocation("IsResolved");
            return true;
        }

        public override PuzzleTemplate Resolve(List<PuzzleField> fields)
        {
            InvocationService.AddOrUpdateInvocation("Resolve");
            return new Sudoku(fields);
        }
    }
}
