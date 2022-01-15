namespace PuzzleSolver.Abstractions
{
    public abstract class GeneratorTemplate
    {
        private readonly IValidator validator;

        protected GeneratorTemplate(IValidator validator)
        {
            this.validator = validator;
        }

        public abstract PuzzleTemplate Generate(int knownFields);

        public bool isValid(PuzzleTemplate puzzle) {
            return validator.IsValid(puzzle.Fields);
        }
    }
}
