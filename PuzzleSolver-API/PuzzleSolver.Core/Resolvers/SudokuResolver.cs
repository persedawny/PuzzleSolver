using PuzzleSolver.Abstractions;
using PuzzleSolver.Core.Validators;

namespace PuzzleSolver.Core.Resolvers
{
    internal class SudokuResolver : ResolverTemplate
    {
        public SudokuResolver(SudokuValidator sudokuValidator) : base(sudokuValidator) { }

        public override string Resolve(string puzzleJson)
        {
            //do
            //{

            //} while (!base);
        }
    }
}
