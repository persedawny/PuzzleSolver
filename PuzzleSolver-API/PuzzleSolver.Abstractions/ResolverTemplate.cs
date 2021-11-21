namespace PuzzleSolver.Abstractions
{
    public abstract class ResolverTemplate
    {
        private readonly IValidator validator;

        public ResolverTemplate(IValidator validator)
        {
            this.validator = validator;
        }

        public abstract string Resolve(string puzzleJson);
    }
}
