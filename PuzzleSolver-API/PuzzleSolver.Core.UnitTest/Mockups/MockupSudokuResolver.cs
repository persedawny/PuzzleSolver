using PuzzleSolver.Abstractions;

namespace PuzzleSolver.Core.UnitTest.Mockups
{
    internal class MockupSudokuResolver : ResolverTemplate
    {
        public InvocationService InvocationService = new InvocationService();

        public override bool IsResolved(PuzzleTemplate puzzleJson)
        {
            InvocationService.AddOrUpdateInvocation("IsResolved");
            //return puzzleJson.Contains('0');
            // TODO Abstratctions zijn veranderd 
        }

        public override PuzzleTemplate Resolve(PuzzleTemplate puzzleJson)
        {
            InvocationService.AddOrUpdateInvocation("Resolve");

            //do
            //{
            //puzzleJson = puzzleJson.Replace('0', '1');
            //}
            //while (puzzleJson.Contains('0'));

            //return puzzleJson;
            // TODO Abstratctions zijn veranderd 
        }
    }
}
