using PuzzleSolver.Abstractions;
using PuzzleSolver.Models.DTO;
using System.Collections.Generic;
using System.Linq;

namespace PuzzleSolver.Core
{
    internal class PuzzleService : IPuzzleService
    {
        private readonly IStackHandler<PuzzleFieldTemplate> stackHandler;
        private readonly IResolver resolver;
        private readonly IValidator validator;
        private readonly GeneratorTemplate generator;

        public PuzzleService(IStackHandler<PuzzleFieldTemplate> stackHandler, IResolver resolver, IValidator validator, GeneratorTemplate generator)
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
                    resolver.Resolve(puzzle.Fields.Select(item => item.ToDTO()));
                    isPuzzleValid = true;
                }
                catch
                {
                    puzzle = generator.Generate(knownFields);
                }
            }

            return puzzle;
        }

        public IEnumerable<string> GetHint(IEnumerable<PuzzleFieldDTO> fields) => resolver.GetHint(fields);

        public PuzzleTemplate Resolve(IEnumerable<PuzzleFieldDTO> fields)
        {
            PuzzleTemplate puzzle = resolver.Resolve(fields);

            while (!validator.IsValid(puzzle.Fields))
            {
                stackHandler.Trash();
                puzzle.Fields = stackHandler.GetFirstOnStack();
                puzzle = resolver.Resolve(puzzle.Fields.Select(item => item.ToDTO()));
            }

            return puzzle;
        }
    }
}
