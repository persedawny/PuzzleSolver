using PuzzleSolver.Abstractions;

namespace PuzzleSolver.Core.UnitTest.Mockups
{
    internal class MockupSudokuResolver : ResolverTemplate
    {
        public MockupSudokuResolver(MockupSudokuValidator sudokuValidator) : base(sudokuValidator) { }

        public override bool IsResolved(string puzzleJson)
        {
            return puzzleJson.Contains('0');
        }

        public override string Resolve(string puzzleJson)
        {
            //do
            //{
                puzzleJson = puzzleJson.Replace('0', '1');
            //} while (!base.CheckMove(puzzleJson));

            return puzzleJson;
        }
    }
}
