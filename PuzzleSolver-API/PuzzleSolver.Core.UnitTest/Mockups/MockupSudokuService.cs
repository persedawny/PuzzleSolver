using PuzzleSolver.Abstractions;
using System.Collections.Generic;
using System.Linq;

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

        public PuzzleTemplate Resolve(List<PuzzleField> fields)
        {
            InvocationService.AddOrUpdateInvocation("Resolve");

            foreach (var item in fields)
            {
                if (item.Value != null)
                    continue;

                item.Value = "1";
            }

            return resolver.Resolve(fields.Select(x => x.ToDTO()).ToList());
        }

        public PuzzleTemplate Resolve(IEnumerable<PuzzleFieldDTO> fields)
        {
            throw new System.NotImplementedException();
        }
    }
}
