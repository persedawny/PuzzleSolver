using Newtonsoft.Json;
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
            List<int?> items = new List<int?>();
            foreach (PuzzleField puzzleField in base.fields)
            {
                SudokuField sudokuField = puzzleField as SudokuField;
                items.Add(sudokuField.Value);
            }
            string json = JsonConvert.SerializeObject(new
            {
                results = items
            });
            return json;
        }

        public override void SetContentFromJson(string json)
        {
            throw new System.NotImplementedException();
        }
    }
}
