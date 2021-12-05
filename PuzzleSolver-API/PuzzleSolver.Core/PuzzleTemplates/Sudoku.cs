using PuzzleSolver.Abstractions;
using PuzzleSolver.Core.Converters;
using System.Collections.Generic;

namespace PuzzleSolver.Core.PuzzleTemplates
{
    class Sudoku : PuzzleTemplate
    {
        public Sudoku(List<PuzzleField> items) : base(items) { }

        public override string GetContentAsJson() => new JsonConverter<Sudoku>().Convert(this);

        public override PuzzleTemplate GetFromJson(string json) => new JsonConverter<Sudoku>().Deserialize(json);
    }
}
