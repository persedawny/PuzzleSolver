using PuzzleSolver.Abstractions;
using PuzzleSolver.Core.PuzzleTemplates;
using System.Collections.Generic;

namespace PuzzleSolver.Core
{
    internal class PuzzleService : IPuzzleService
    {
        private readonly ResolverTemplate resolver;
        private readonly IValidator validator;
        private readonly GeneratorTemplate generator;

        public PuzzleService(ResolverTemplate resolver, IValidator validator, GeneratorTemplate generator)
        {
            this.resolver = resolver;
            this.validator = validator;
            this.generator = generator;
        }

        public bool CheckState(PuzzleTemplate puzzleJson)
        {
            // TODO: Implement after unit tests
            throw new System.NotImplementedException();
        }

        public PuzzleTemplate Generate(int knownFields)
        {
            return generator.Generate(knownFields);
        }

        public PuzzleTemplate Resolve(PuzzleTemplate puzzle)
        {
            List<PuzzleField> easySudoku = new List<PuzzleField>()
            {
                new SudokuField(1), new SudokuField(), new SudokuField(), new SudokuField(), new SudokuField(), new SudokuField(7), new SudokuField(), new SudokuField(9), new SudokuField(),
                new SudokuField(), new SudokuField(3), new SudokuField(), new SudokuField(), new SudokuField(2), new SudokuField(), new SudokuField(), new SudokuField(), new SudokuField(8),
                new SudokuField(), new SudokuField(), new SudokuField(9), new SudokuField(6), new SudokuField(), new SudokuField(), new SudokuField(5), new SudokuField(), new SudokuField(),
                new SudokuField(), new SudokuField(), new SudokuField(5), new SudokuField(3), new SudokuField(), new SudokuField(), new SudokuField(9), new SudokuField(), new SudokuField(),
                new SudokuField(), new SudokuField(1), new SudokuField(), new SudokuField(), new SudokuField(8), new SudokuField(), new SudokuField(), new SudokuField(), new SudokuField(2),
                new SudokuField(6), new SudokuField(), new SudokuField(), new SudokuField(), new SudokuField(), new SudokuField(4), new SudokuField(), new SudokuField(), new SudokuField(),
                new SudokuField(3), new SudokuField(), new SudokuField(), new SudokuField(4), new SudokuField(), new SudokuField(), new SudokuField(), new SudokuField(1), new SudokuField(),
                new SudokuField(), new SudokuField(4), new SudokuField(1), new SudokuField(), new SudokuField(), new SudokuField(), new SudokuField(), new SudokuField(), new SudokuField(7),
                new SudokuField(), new SudokuField(), new SudokuField(7), new SudokuField(), new SudokuField(), new SudokuField(1), new SudokuField(3), new SudokuField(), new SudokuField(),
            };

            List<PuzzleField> hardSudoku = new List<PuzzleField>()
            {
                new SudokuField(8), new SudokuField(), new SudokuField(), new SudokuField(), new SudokuField(), new SudokuField(), new SudokuField(), new SudokuField(), new SudokuField(),
                new SudokuField(), new SudokuField(), new SudokuField(3), new SudokuField(6), new SudokuField(), new SudokuField(), new SudokuField(), new SudokuField(), new SudokuField(),
                new SudokuField(), new SudokuField(7), new SudokuField(), new SudokuField(), new SudokuField(9), new SudokuField(), new SudokuField(2), new SudokuField(), new SudokuField(),
                new SudokuField(), new SudokuField(5), new SudokuField(), new SudokuField(), new SudokuField(), new SudokuField(7), new SudokuField(), new SudokuField(), new SudokuField(),
                new SudokuField(), new SudokuField(), new SudokuField(), new SudokuField(), new SudokuField(4), new SudokuField(5), new SudokuField(7), new SudokuField(), new SudokuField(),
                new SudokuField(), new SudokuField(), new SudokuField(), new SudokuField(1), new SudokuField(), new SudokuField(), new SudokuField(), new SudokuField(3), new SudokuField(),
                new SudokuField(), new SudokuField(), new SudokuField(1), new SudokuField(), new SudokuField(), new SudokuField(), new SudokuField(), new SudokuField(6), new SudokuField(8),
                new SudokuField(), new SudokuField(), new SudokuField(8), new SudokuField(5), new SudokuField(), new SudokuField(), new SudokuField(), new SudokuField(1), new SudokuField(),
                new SudokuField(), new SudokuField(8), new SudokuField(), new SudokuField(), new SudokuField(), new SudokuField(), new SudokuField(4), new SudokuField(), new SudokuField(),
            };

            PuzzleTemplate puzzle2 = new Sudoku(easySudoku);
            return resolver.Resolve(puzzle2);
        }
    }
}
