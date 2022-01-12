using PuzzleSolver.Abstractions;
using PuzzleSolver.Models.DTO;
using System.Collections.Generic;
using System.Linq;

namespace PuzzleSolver.Core.UnitTest.Mockups
{
    internal class Mockup_SudokuService : IPuzzleService
    {
        private readonly Mockup_SudokuGenerator generator;
        private readonly Mockup_SudokuResolver resolver;
        private readonly Mockup_SudokuValidator validator;

        public InvocationService InvocationService = new InvocationService();

        public Mockup_SudokuService()
        {
            validator = new Mockup_SudokuValidator();
            generator = new Mockup_SudokuGenerator(validator);
            resolver = new Mockup_SudokuResolver();
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

        public IEnumerable<string> GetHint(IEnumerable<PuzzleFieldDTO> fields)
        {
            throw new System.NotImplementedException();
        }

        public PuzzleTemplate Resolve(List<PuzzleFieldTemplate> fields)
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
