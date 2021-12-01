using PuzzleSolver.Abstractions;

namespace PuzzleSolver.Core.UnitTest.Mockups
{
    internal class MockupSudokuResolver : ResolverTemplate
    {
        public InvocationService InvocationService = new InvocationService();

        public override bool IsResolved(string puzzleJson)
        {
            InvocationService.AddOrUpdateInvocation("IsResolved");
            return puzzleJson.Contains('0');
        }

        public override string Resolve(string puzzleJson)
        {
            InvocationService.AddOrUpdateInvocation("Resolve");

            do
            {
                puzzleJson = puzzleJson.Replace('0', '1');
            }
            while (puzzleJson.Contains('0'));

            return puzzleJson;
        }
    }
}
