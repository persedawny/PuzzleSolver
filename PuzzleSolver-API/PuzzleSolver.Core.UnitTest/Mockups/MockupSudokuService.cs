﻿using PuzzleSolver.Abstractions;

namespace PuzzleSolver.Core.UnitTest.Mockups
{
    internal class MockupSudokuService : InvocationService, IPuzzleService
    {
        private readonly MockupSudokuGenerator generator;
        private readonly MockupSudokuResolver resolver;
        private readonly MockupSudokuValidator validator;

        public InvocationService InvocationService = new InvocationService();

        public MockupSudokuService()
        {
            validator = new MockupSudokuValidator();
            generator = new MockupSudokuGenerator(validator);
            resolver = new MockupSudokuResolver();
        }

        public bool CheckState(PuzzleTemplate puzzleJson)
        {
            InvocationService.AddOrUpdateInvocation("CheckState");

            return true;
        }

        public PuzzleTemplate Generate(int knownFields)
        {
            InvocationService.AddOrUpdateInvocation("Generate");

            return generator.Generate(knownFields);
        }

        public PuzzleTemplate Resolve(PuzzleTemplate puzzleJson)
        {
            InvocationService.AddOrUpdateInvocation("Resolve");

            return resolver.Resolve(puzzleJson);
        }
    }
}
