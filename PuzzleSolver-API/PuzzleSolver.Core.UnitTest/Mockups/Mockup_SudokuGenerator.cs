using PuzzleSolver.Abstractions;
using System.Collections.Generic;

namespace PuzzleSolver.Core.UnitTest.Mockups
{
    internal class Mockup_SudokuGenerator : GeneratorTemplate
    {
        public InvocationService InvocationService = new InvocationService();

        public Mockup_SudokuGenerator(Mockup_SudokuValidator sudokuValidator) : base(sudokuValidator) { }

        public override PuzzleTemplate Generate(int knownFields)
        {
            InvocationService.AddOrUpdateInvocation("Generate");

            var returnList = new List<PuzzleFieldTemplate>();

            for (int i = 0; i < knownFields; i++)
            {
                returnList.Add(new Mockup_SudokuField("1"));
            }

            for (int i = 0; i < (81 - knownFields); i++)
            {
                returnList.Add(new Mockup_SudokuField());
            }

            return new Mockup_Sudoku(returnList);
        }
    }
}
