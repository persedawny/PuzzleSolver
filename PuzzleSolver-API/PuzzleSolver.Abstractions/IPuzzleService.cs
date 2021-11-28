namespace PuzzleSolver.Abstractions
{
    public interface IPuzzleService
    {
        public string Generate(int knownFields);
        public bool CheckState(string puzzleJson);
        public string Resolve(string puzzleJson);
    }
}
