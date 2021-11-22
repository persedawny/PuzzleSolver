﻿using PuzzleSolver.Abstractions;
using PuzzleSolver.API;
using PuzzleSolver.Core.Generators;
using PuzzleSolver.Core.Resolvers;
using PuzzleSolver.Core.Validators;

namespace PuzzleSolver.Core
{
    public class PuzzleServiceFactory
    {
        public static IPuzzleService GetSudokuController()
        {
            var validator = new SudokuValidator();
            return new PuzzleService(new SudokuResolver(validator), validator, new SudokuGenerator(validator));
        }
    }
}
