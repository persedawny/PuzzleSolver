using PuzzleSolver.Abstractions;
using System.Collections.Generic;
using System.Linq;

namespace PuzzleSolver.Core.UnitTest.Mockups
{
    internal class MockupSudokuResolver : ResolverTemplate
    {
        public InvocationService InvocationService = new InvocationService();

        public override PuzzleTemplate Resolve(IEnumerable<PuzzleFieldDTO> fields)
        {
            InvocationService.AddOrUpdateInvocation("Resolve");

            foreach (var item in fields)
            {
                if (string.IsNullOrEmpty(item.Value))
                    item.Value = "1";
            }

            var abstractFields = fields.Select(x => (PuzzleField)new SudokuField(x.Value)).ToList();

            return new Sudoku(abstractFields);
        }
    }
}
