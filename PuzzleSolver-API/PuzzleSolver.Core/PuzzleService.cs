using PuzzleSolver.Abstractions;
using System.Collections.Generic;
using System.Linq;

namespace PuzzleSolver.Core
{
    internal class PuzzleService : IPuzzleService
    {
        private readonly IStackHandler<PuzzleFieldTemplate> stackHandler;
        private readonly ResolverTemplate resolver;
        private readonly IValidator validator;
        private readonly GeneratorTemplate generator;

        public PuzzleService(IStackHandler<PuzzleFieldTemplate> stackHandler, ResolverTemplate resolver, IValidator validator, GeneratorTemplate generator)
        {
            this.stackHandler = stackHandler;
            this.resolver = resolver;
            this.validator = validator;
            this.generator = generator;
        }

        public PuzzleTemplate Generate(int knownFields)
        {
            var isPuzzleValid = false;
            var puzzle = generator.Generate(knownFields);

            while (!isPuzzleValid)
            {
                try
                {
                    resolver.Resolve(puzzle.fields.Select(item => item.ToDTO()));
                    isPuzzleValid = true;
                }
                catch
                {
                    puzzle = generator.Generate(knownFields);
                }
            }

            return puzzle;
        }

        public PuzzleTemplate Resolve(IEnumerable<PuzzleFieldDTO> fields)
        {
            PuzzleTemplate puzzle = resolver.Resolve(fields);

            while (!validator.IsValid(puzzle.fields))
            {
                stackHandler.Trash();
                puzzle.fields = stackHandler.GetFirstOnStack();
                puzzle = resolver.Resolve(puzzle.fields.Select(item => item.ToDTO()));
            }

            return puzzle;
        }
    }
}
