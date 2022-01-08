namespace PuzzleSolver.Abstractions
{
    public class PuzzleEntity
    {
        public int Id { get; set; }
        public PuzzleEntityType Type { get; set; }
        public string Json { get; set; }
    }
}
