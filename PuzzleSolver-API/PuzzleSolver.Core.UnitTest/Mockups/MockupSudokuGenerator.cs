using PuzzleSolver.Abstractions;
using System.Collections.Generic;

namespace PuzzleSolver.Core.UnitTest.Mockups
{
    internal class MockupSudokuGenerator : GeneratorTemplate
    {
        public InvocationService InvocationService = new InvocationService();

        public MockupSudokuGenerator(MockupSudokuValidator sudokuValidator) : base(sudokuValidator) { }

        public override PuzzleTemplate Generate(int knownFields)
        {
            InvocationService.AddOrUpdateInvocation("Generate");

            var returnList = new List<PuzzleFieldTemplate>();

            for (int i = 0; i < knownFields; i++)
            {
                returnList.Add(new SudokuField("1"));
            }

            for (int i = 0; i < (81 - knownFields); i++)
            {
                returnList.Add(new SudokuField());
            }

            return new Sudoku(returnList);
        }
    }
}
