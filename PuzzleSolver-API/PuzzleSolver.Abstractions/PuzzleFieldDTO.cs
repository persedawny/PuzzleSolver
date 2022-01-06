namespace PuzzleSolver.Abstractions
{
    public class PuzzleFieldDTO
    {
        public string? Value { get; set; }

        public PuzzleFieldDTO(PuzzleField field)
        {
            Value = field.Value;
        }
    }
}
