using PuzzleSolver.Abstractions;

namespace PuzzleSolver.API
{
    internal class PuzzleController : IPuzzleController
    {
        private readonly IResolver resolver;
        private readonly IValidator validator;
        private readonly IGenerator generator;

        public PuzzleController(IResolver resolver, IValidator validator, IGenerator generator)
        {
            this.resolver = resolver;
            this.validator = validator;
            this.generator = generator;
        }

        public PuzzleTemplate Generate(int knownFields)
        {
            return generator.Generate(knownFields);
        }
    }
}
