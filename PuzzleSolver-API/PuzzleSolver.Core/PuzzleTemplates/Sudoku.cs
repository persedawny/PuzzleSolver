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
            // TODO: Implement after unit tests
            //throw new System.NotImplementedException();
            return "";
        }

        public override void SetContentFromJson(string json)
        {
            throw new System.NotImplementedException();
        }
    }
}
