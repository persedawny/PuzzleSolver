using PuzzleSolver.Abstractions;
using System.Collections.Generic;
using System.Linq;

namespace PuzzleSolver.Core.Sudoku
{
    internal class Resolver : ResolverTemplate
    {
        private readonly IStackHandler<PuzzleField> stackHandler;

        public Resolver(IStackHandler<PuzzleField> stackHandler)
        {
            this.stackHandler = stackHandler;
        }

        public override PuzzleTemplate Resolve(IEnumerable<PuzzleFieldDTO> puzzleFields)
        {
            var fields = puzzleFields.Select(x => new Field(x.Value) as PuzzleField).ToList();
            var puzzle = new Puzzle(fields);

            puzzle.SetIndexes();

            while (!puzzle.AllFieldsHaveValue)
            {
                puzzle.LoopAndGetPotentialValues();

                if (puzzle.HasFieldsWithOnePotential)
                {
                    FillInSimpleSquares(puzzle.fields);
                }
                else
                {
                    stackHandler.CreateStack(puzzle.fields);
                    puzzle.fields = stackHandler.GetFirstOnStack();
                }
            }

            return puzzle;
        }

        void FillInSimpleSquares(List<PuzzleField> fields)
        {
            foreach (var field in fields)
            {
                if (!field.HasValue && field.PotentialValues.Count == 1)
                {
                    field.Value = field.PotentialValues.First();
                    field.PotentialValues.RemoveAt(0);
                }
            }
        }
    }
}
