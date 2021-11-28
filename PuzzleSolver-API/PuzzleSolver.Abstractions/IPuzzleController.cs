namespace PuzzleSolver.Abstractions
{
    public interface IPuzzleController
    {
        public string Generate(int knownFields);
        public bool CheckState(string puzzleJson);
        public string Resolve(string puzzleJson);
    }
}
