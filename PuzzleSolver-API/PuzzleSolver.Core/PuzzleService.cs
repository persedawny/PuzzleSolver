using PuzzleSolver.Abstractions;
using PuzzleSolver.Core.PuzzleTemplates;
using System.Collections.Generic;

namespace PuzzleSolver.Core
{
    internal class PuzzleService<T> : IPuzzleService where T : PuzzleField
    {
        private readonly ResolverTemplate<T> resolver;
        private readonly IValidator validator;
        private readonly GeneratorTemplate generator;

        public PuzzleService(ResolverTemplate<T> resolver, IValidator validator, GeneratorTemplate generator)
        {
            this.resolver = resolver;
            this.validator = validator;
            this.generator = generator;
        }

        public bool CheckState(string puzzleJson)
        {
            // TODO: Implement after unit tests
            throw new System.NotImplementedException();
        }

        public string Generate(int knownFields)
        {
            // TODO: Implement after unit tests
            return generator.Generate(knownFields);
        }

        public string Resolve(string puzzleJson)
        {
            List<SudokuField> easySudoku = new List<SudokuField>()
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

            List<SudokuField> hardSudoku = new List<SudokuField>()
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

            Sudoku puzzle = new Sudoku(easySudoku);
            resolver.Resolve(puzzle.fields);
            return "";
        }
    }
}
