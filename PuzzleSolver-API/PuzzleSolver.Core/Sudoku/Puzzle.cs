using PuzzleSolver.Abstractions;
using PuzzleSolver.Core.Converters;
using System.Collections.Generic;

namespace PuzzleSolver.Core.Sudoku
{
    class Puzzle : PuzzleTemplate
    {
        public Puzzle(List<PuzzleField> items) : base(items) { }

        public override string GetContentAsJson() => new JsonConverter<Puzzle>().Convert(this);

        public override PuzzleTemplate GetFromJson(string json) => new JsonConverter<Puzzle>().Deserialize(json);
    }
}
