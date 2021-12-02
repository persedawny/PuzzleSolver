namespace PuzzleSolver.Abstractions
{
    public interface IValidator
    {
        public bool IsValid(PuzzleTemplate puzzle);
        public bool IsValidMove(PuzzleTemplate puzzle);
    }
}
