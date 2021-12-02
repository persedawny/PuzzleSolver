namespace PuzzleSolver.Abstractions
{
    public interface IPuzzleService
    {
        public PuzzleTemplate Generate(int knownFields);
        public bool CheckState(PuzzleTemplate puzzleJson);
        public PuzzleTemplate Resolve(PuzzleTemplate puzzle);
    }
}
