using PuzzleSolver.Abstractions;
using System.Collections.Generic;
using System.Linq;

namespace PuzzleSolver.Core.Sudoku
{

    internal class Resolver : ResolverTemplate
    {
        private readonly IStackHandler<Field> stackHandler;
        private readonly IMapper<Field> mapper;

        public Resolver(IStackHandler<Field> stackHandler, IMapper<Field> mapper)
        {
            this.stackHandler = stackHandler;
            this.mapper = mapper;
        }

        public override PuzzleTemplate Resolve(List<PuzzleField> puzzleFields)
        {
            var puzzle = new Puzzle(puzzleFields, mapper);

            puzzle.SetIndexes();

            while (!puzzle.AllFieldsHaveValue)
            {
                puzzle.LoopAndGetPotentialValues();

                if (puzzle.HasFieldsWithOnePotential)
                {
                    FillInSimpleSquares(puzzle.fields);
                    puzzle.notify(mapper.MapListToAbstraction(puzzle.fields));
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
