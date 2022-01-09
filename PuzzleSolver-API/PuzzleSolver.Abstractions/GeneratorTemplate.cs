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

        //TODO: als het goed is niet meer nodig
        public bool isValid(PuzzleTemplate puzzle) {
            return validator.IsValid(puzzle.fields);
        }
    }
}
