using PuzzleSolver.Abstractions;

namespace PuzzleSolver.API
{
    public class PuzzleController
    {
        private readonly PuzzleTemplate puzzle;
        private readonly IResolver resolver;
        private readonly IValidator validator;
        private readonly IGenerator generator;

        public PuzzleController(PuzzleTemplate puzzle, IResolver resolver, IValidator validator, IGenerator generator)
        {
            this.puzzle = puzzle;
            this.resolver = resolver;
            this.validator = validator;
            this.generator = generator;
        }
    }
}
