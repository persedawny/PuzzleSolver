namespace PuzzleSolver.Abstractions
{
    public abstract class PuzzleTemplate
    {
        public abstract string GetContentAsJson();
        public abstract void SetContentFromJson(string json);
    }
}
