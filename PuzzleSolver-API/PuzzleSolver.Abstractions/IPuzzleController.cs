namespace PuzzleSolver.Abstractions
{
    public interface IPuzzleController
    {
        public string Generate(int knownFields);
        public bool CheckState(PuzzleTemplate puzzle);
        public string Resolve(PuzzleTemplate puzzle);
    }
}
