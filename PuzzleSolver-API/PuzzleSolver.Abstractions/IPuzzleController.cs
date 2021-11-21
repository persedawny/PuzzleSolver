namespace PuzzleSolver.Abstractions
{
    public interface IPuzzleController
    {
        public PuzzleTemplate Generate(int difficulty);
        public bool CheckState(string puzzleJson);
    }
}
