using PuzzleSolver.Abstractions;
using PuzzleSolver.Core.Sudoku;
using System.Collections.Generic;

namespace PuzzleSolver.Core
{
    internal class PuzzleService : IPuzzleService
    {
        private readonly StackHandler stackHandler;
        private readonly ResolverTemplate resolver;
        private readonly IValidator validator;
        private readonly GeneratorTemplate generator;

        public PuzzleService(StackHandler stackHandler, ResolverTemplate resolver, IValidator validator, GeneratorTemplate generator)
        {
            this.stackHandler = stackHandler;
            this.resolver = resolver;
            this.validator = validator;
            this.generator = generator;
        }

        public bool CheckState(PuzzleTemplate puzzleJson)
        {
            // TODO: Implement after unit tests
            throw new System.NotImplementedException();
        }

        private PuzzleTemplate GeneratePuzzle(int knownFields)
        {
            return generator.Generate(knownFields);
        }

        public PuzzleTemplate Generate(int knownFields)
        {
            var isPuzzleValid = false;
            var puzzle = GeneratePuzzle(knownFields);

            while (!isPuzzleValid)
            {
                try
                {
                    resolver.Resolve(puzzle.fields);
                    isPuzzleValid = true;
                }
                catch
                {
                    puzzle = GeneratePuzzle(knownFields);
                }
            }
            return puzzle;
        }

        public PuzzleTemplate Resolve(List<PuzzleField> fields)
        {
            PuzzleTemplate puzzle = resolver.Resolve(fields);

            while (!validator.IsValid(puzzle.fields))
            {
                puzzle = resolver.Resolve(puzzle.fields);
            }

            return puzzle;
        }
    }
}
