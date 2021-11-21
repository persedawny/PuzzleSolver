using PuzzleSolver.Abstractions;

namespace PuzzleSolver.Core.UnitTest.Mockups
{
    internal class MockupSudokuResolver : ResolverTemplate
    {
        public InvocationService InvocationService = new InvocationService();

        public MockupSudokuResolver(MockupSudokuValidator sudokuValidator) : base(sudokuValidator) { }

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
                do
                {
                    puzzleJson = puzzleJson.Replace('0', '1');
                } while (!base.CheckMove(puzzleJson));
            }
            while (puzzleJson.Contains('0'));

            return puzzleJson;
        }
    }
}
