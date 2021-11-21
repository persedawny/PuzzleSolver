namespace PuzzleSolver.Abstractions
{
    public interface IPuzzleService
    {
        PuzzleTemplate Generate(int knownFields);
    }
}
