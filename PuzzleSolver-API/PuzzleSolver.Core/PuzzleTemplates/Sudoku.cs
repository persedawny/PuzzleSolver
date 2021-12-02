using PuzzleSolver.Abstractions;
using System.Collections.Generic;

namespace PuzzleSolver.Core.PuzzleTemplates
{
    internal class Sudoku : PuzzleTemplate<SudokuField>
    {
        public Sudoku(List<SudokuField> items): base(items) { }

        public override string GetContentAsJson()
        {
            // TODO: Implement after unit tests
            throw new System.NotImplementedException();
        }

        public override void SetContentFromJson(string json)
        {
            // TODO: Implement after test
            throw new System.NotImplementedException();
        }
    }
}
