using PuzzleSolver.Abstractions;
using System.Collections.Generic;
using System.Linq;

namespace PuzzleSolver.Core.PuzzleTemplates
{
    class Sudoku : PuzzleTemplate
    {
        public Sudoku(List<PuzzleField> items) : base(items) { }

        public override string GetContentAsJson()
        {
            throw new System.NotImplementedException();
        }

        public override PuzzleTemplate SetContentFromJson(string json)
        {
            throw new System.NotImplementedException();
        }
    }
}
