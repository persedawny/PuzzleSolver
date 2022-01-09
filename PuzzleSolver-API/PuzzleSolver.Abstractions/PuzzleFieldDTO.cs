namespace PuzzleSolver.Abstractions
{
    public class PuzzleFieldDTO
    {
        public string? Value { get; set; }

        public PuzzleFieldDTO() { }

        public PuzzleFieldDTO(PuzzleFieldTemplate field)
        {
            Value = field.Value;
        }
    }
}
