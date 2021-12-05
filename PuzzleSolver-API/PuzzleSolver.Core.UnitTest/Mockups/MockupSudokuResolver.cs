using PuzzleSolver.Abstractions;

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

        public override PuzzleTemplate Resolve(PuzzleTemplate puzzle)
        {
            InvocationService.AddOrUpdateInvocation("Resolve");
            return puzzle;
        }
    }
}
