namespace PuzzleSolver.Abstractions
{
    public abstract class GeneratorTemplate
    {
        private readonly IValidator validator;

        public GeneratorTemplate(IValidator validator)
        {
            this.validator = validator;
        }

        public abstract PuzzleTemplate Generate(int knownFields);

        public bool isValid(PuzzleTemplate puzzle) {
            return validator!.IsValid(puzzle);
        }
    }
}
