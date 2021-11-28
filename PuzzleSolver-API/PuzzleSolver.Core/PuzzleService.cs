using PuzzleSolver.Abstractions;

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

        public bool CheckState(string puzzleJson)
        {
            // TODO: Implement after unit tests
            throw new System.NotImplementedException();
        }

        public PuzzleTemplate Generate(int knownFields)
        {
            // TODO: Implement after unit tests
            return generator.Generate(knownFields);
        }

        public string Resolve(string puzzleJson) => resolver.Resolve(puzzleJson);
    }
}
