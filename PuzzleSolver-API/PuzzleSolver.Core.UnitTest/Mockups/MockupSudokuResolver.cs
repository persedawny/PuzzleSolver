using PuzzleSolver.Abstractions;

namespace PuzzleSolver.Core.UnitTest.Mockups
{
    internal class MockupSudokuResolver : ResolverTemplate
    {
        public MockupSudokuResolver(MockupSudokuValidator sudokuValidator) : base(sudokuValidator) { }

        public override string Resolve(string puzzleJson)
        {
            throw new System.NotImplementedException();
        }
    }
}
