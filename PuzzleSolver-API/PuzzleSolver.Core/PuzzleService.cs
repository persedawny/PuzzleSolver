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

        public PuzzleTemplate Generate(int knownFields)
        {
            return generator.Generate(knownFields);
        }

        public PuzzleTemplate Resolve(List<PuzzleField> fields)
        {
            return resolver.Resolve(fields);
        }
    }
}
