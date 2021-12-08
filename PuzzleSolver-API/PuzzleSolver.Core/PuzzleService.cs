using PuzzleSolver.Abstractions;
using System.Collections.Generic;

namespace PuzzleSolver.Core
{
    internal class PuzzleService : IPuzzleService
    {
        private readonly ResolverTemplate resolver;
        private readonly IValidator validator;
        private readonly GeneratorTemplate generator;

        public PuzzleService(ResolverTemplate resolver, IValidator validator, GeneratorTemplate generator)
        {
            this.resolver = resolver;
            this.validator = validator;
            this.generator = generator;
        }

        public bool CheckState(PuzzleTemplate puzzleJson)
        {
            // TODO: Implement after unit tests
            throw new System.NotImplementedException();
        }

        private PuzzleTemplate GeneratePuzzle(int knownFields) {
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
            var solvedPuzzle = resolver.Resolve(fields);

            while (!validator.IsValid(fields))
            {
                //TODO: Trash
                solvedPuzzle = resolver.Resolve(fields);
                fields = solvedPuzzle.fields;
            }
            return solvedPuzzle;
        }
    }
}
