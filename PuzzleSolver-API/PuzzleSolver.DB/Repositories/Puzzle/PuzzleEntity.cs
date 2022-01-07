namespace PuzzleSolver.DB.Repositories.Puzzle
{
    internal class PuzzleEntity
    {
        public int Id { get; set; }
        public PuzzleEntityType Type { get; set; }
        public string Json { get; set; }
    }
}
