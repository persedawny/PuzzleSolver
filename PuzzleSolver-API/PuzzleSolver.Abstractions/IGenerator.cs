namespace PuzzleSolver.Abstractions
{
    public interface IGenerator
    {
        PuzzleTemplate Generate(int knownFields);
    }
}
