using PuzzleSolver.Abstractions;

namespace PuzzleSolver.API
{
    public class PuzzleController
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
    }
}
