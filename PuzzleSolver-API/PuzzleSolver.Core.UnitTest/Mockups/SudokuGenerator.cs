using PuzzleSolver.Abstractions;
using System;

namespace PuzzleSolver.Core.UnitTest.Mockups
{
    internal class SudokuGenerator : BaseMockup, IGenerator
    {
        internal Sudoku Generate(int knownFields)
        {
            AddOrUpdateInvocation("Generate");

            return new Sudoku();
        }
    }
}
