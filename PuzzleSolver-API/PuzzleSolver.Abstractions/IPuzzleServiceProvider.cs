namespace PuzzleSolver.Abstractions
{
    public interface IPuzzleServiceProvider
    {
        IPuzzleService GetSudokuService();
    }
}
