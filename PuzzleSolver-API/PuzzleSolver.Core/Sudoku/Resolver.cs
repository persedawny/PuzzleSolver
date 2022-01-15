using PuzzleSolver.Abstractions;
using PuzzleSolver.Models.DTO;
using System.Collections.Generic;
using System.Linq;

namespace PuzzleSolver.Core.Sudoku
{
    internal class Resolver : IResolver
    {
        private readonly IStackHandler<PuzzleFieldTemplate> stackHandler;

        public Resolver(IStackHandler<PuzzleFieldTemplate> stackHandler)
        {
            this.stackHandler = stackHandler;
        }

        public IEnumerable<string> GetHint(IEnumerable<PuzzleFieldDTO> puzzleFields)
        {
            var fields = puzzleFields.Select(x => new Field(x.Value) as PuzzleFieldTemplate).ToList();
            var puzzle = new Puzzle(fields);

            puzzle.SetIndexes();

            puzzle.LoopAndGetPotentialValues();

            return puzzle.Fields.FirstOrDefault(x => x.Value == null).PotentialValues;
        }

        public PuzzleTemplate Resolve(IEnumerable<PuzzleFieldDTO> puzzleFields)
        {
            var fields = puzzleFields.Select(x => new Field(x.Value) as PuzzleFieldTemplate).ToList();
            var puzzle = new Puzzle(fields);

            puzzle.SetIndexes();

            while (!puzzle.AllFieldsHaveValue)
            {
                puzzle.LoopAndGetPotentialValues();

                if (puzzle.HasFieldsWithOnePotential)
                {
                    FillInSimpleSquares(puzzle.Fields);
                }
                else
                {
                    stackHandler.CreateStack(puzzle.Fields);
                    puzzle.Fields = stackHandler.GetFirstOnStack();
                }
            }

            return puzzle;
        }

        private void FillInSimpleSquares(List<PuzzleFieldTemplate> fields)
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
