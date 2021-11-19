namespace PuzzleSolver.Abstractions
{
    public interface IPuzzleController
    {
        public PuzzleTemplate Generate(int knownFields);
    }
}
