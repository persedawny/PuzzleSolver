namespace PuzzleSolver.Abstractions
{
    public interface IValidator
    {
        public bool IsValid(string puzzleJson);
        public bool IsValidMove(string puzzleJson);
    }
}
