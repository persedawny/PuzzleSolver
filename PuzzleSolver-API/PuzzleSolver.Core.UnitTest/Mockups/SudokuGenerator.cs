using PuzzleSolver.Abstractions;
using System;

namespace PuzzleSolver.Core.UnitTest.Mockups
{
    internal class SudokuGenerator : BaseMockup, IGenerator
    {
        internal Sudoku Generate(int knownFields)
        {
            // TODO: Make a real mockup implementation
            AddOrUpdateInvocation("Generate");

            return new Sudoku();
        }
    }
}
