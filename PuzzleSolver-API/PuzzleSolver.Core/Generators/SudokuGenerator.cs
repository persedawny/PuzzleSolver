using PuzzleSolver.Abstractions;
using PuzzleSolver.Core.Validators;
using System;

namespace PuzzleSolver.Core.Generators
{
    internal class SudokuGenerator : GeneratorTemplate
    {
        public SudokuGenerator(SudokuValidator sudokuValidator) : base(sudokuValidator) { }

        public override PuzzleTemplate Generate(int knownFields)
        {
            // TODO: Implement after test
            throw new NotImplementedException();
        }
    }
}