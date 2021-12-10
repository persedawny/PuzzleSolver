using PuzzleSolver.Abstractions;
using System.Collections.Generic;
using System.Linq;

namespace PuzzleSolver.Core.Sudoku
{

    internal class Resolver : ResolverTemplate
    {
        private readonly StackHandler stackHandler;

        public Resolver(StackHandler stackProvider)
        {
            this.stackHandler = stackProvider;
        }

        public override PuzzleTemplate Resolve(List<PuzzleField> puzzleFields)
        {
            var puzzle = new Puzzle(puzzleFields);

            puzzle.SetIndexes();

            while (!puzzle.AllFieldsHaveValue)
            {
                puzzle.LoopAndGetPotentialValues();

                if (puzzle.HasFieldsWithOnePotential)
                {
                    FillInSimpleSquares(puzzle.fields);
                    puzzle.notify(FieldMapper.MapListToAbstraction(puzzle.fields));
                }
                else
                {
                    stackHandler.CreateStack(puzzle.fields);
                    puzzle.fields = stackHandler.GetFirstOnStack();
                }
            }

            return puzzle;
        }

        void FillInSimpleSquares(List<Field> fields)
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
