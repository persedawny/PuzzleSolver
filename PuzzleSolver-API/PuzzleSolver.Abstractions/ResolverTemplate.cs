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

        public abstract bool IsResolved(string puzzleJson);

        public bool CheckMove(string puzzleJson)
        {
            return validator.IsValidMove(puzzleJson);
        }
    }
}
