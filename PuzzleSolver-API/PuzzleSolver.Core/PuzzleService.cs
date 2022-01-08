using PuzzleSolver.Abstractions;
using System.Collections.Generic;
using System.Linq;

namespace PuzzleSolver.Core
{
    internal class PuzzleService : IPuzzleService
    {
        private readonly IStackHandler<PuzzleField> stackHandler;
        private readonly ResolverTemplate resolver;
        private readonly IValidator validator;
        private readonly GeneratorTemplate generator;
        private readonly IRepository<PuzzleEntity> puzzleRepository;

        public PuzzleService(IRepository<PuzzleEntity> repository, IStackHandler<PuzzleField> stackHandler, ResolverTemplate resolver, IValidator validator, GeneratorTemplate generator)
        {
            this.stackHandler = stackHandler;
            this.resolver = resolver;
            this.validator = validator;
            this.generator = generator;
            puzzleRepository = repository;
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
                    var dtoList = (from item in puzzle.fields
                                   select item.ToDTO()).ToList();

                    resolver.Resolve(dtoList);
                    isPuzzleValid = true;
                }
                catch
                {
                    puzzle = GeneratePuzzle(knownFields);
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

                var dtoList = (from item in puzzle.fields
                               select item.ToDTO()).ToList();

                puzzle = resolver.Resolve(dtoList);
            }

            return puzzle;
        }
    }
}
