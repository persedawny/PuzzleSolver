using PuzzleSolver.Abstractions;
using PuzzleSolver.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PuzzleSolver.Core.Sudoku
{
    internal class Resolver : ResolverTemplate
    {
        private List<List<Field>> stack = new List<List<Field>>();
        private List<Field> fields = new List<Field>();

        public override PuzzleTemplate Resolve(List<PuzzleField> puzzleFields)
        {
            var puzzle = new Puzzle(puzzleFields);
            fields = FieldMapper.MapListToImplementationList(puzzleFields);

            SetIndexes();

            while (!AllFieldsHaveValue())
            {
                LoopAndGetPotentialValues();

                if (fields.Select(f => f.PotentialValues.Count == 1).Contains(true))
                {
                    FillInSimpleSquares(fields);
                }
                else
                {
                    CreateStack(fields);
                    fields = stack.First();
                    puzzle.fields = FieldMapper.MapListToAbstractionList(fields);
                }
            }

            puzzle.fields = FieldMapper.MapListToAbstractionList(fields);

            return puzzle;
        }

        private bool AllFieldsHaveValue() => fields.Count(x => !x.HasValue) > 0;

        void Trash()
        {
            if (stack.Count == 0)
                throw new UnsolvablePuzzleException();

            stack.RemoveAt(0);
        }

        void FillInSimpleSquares(List<Field> fields)
        {
            foreach (var field in fields)
            {
                if (!field.HasValue && field.PotentialValues.Count == 1)
                {
                    field.Value = field.PotentialValues.First();
                    field.PotentialValues.RemoveAt(0);
                }
            }
        }

        void SetIndexes()
        {
            int index = 0;
            foreach (var field in fields)
            {
                field.Index = index;
                index++;
            }   
        }

        void LoopAndGetPotentialValues()
        {
            foreach (Field field in fields)
            {
                if (field.HasValue) continue;

                foreach (Field compareField in fields)
                {
                    /*
                     * Lege velden, niet gerelateerde velden en getallen
                     * die niet in de Potentials voorkomen overslaan!
                     */

                    if (!compareField.HasValue)
                        continue;

                    if (!field.IsRelatedTo(compareField))
                        continue;

                    if (!field.PotentialValues.Contains(compareField.Value))
                        continue;

                    field.PotentialValues.Remove(compareField.Value);
                }
            }
        }

        void CreateStack(List<Field> fields)
        {
            int size = GetNextPotentialSize(fields);

            if (size == 0)
            {
                Trash();
                return;
            }

            IEnumerable<Field> iterable = fields.Cast<Field>().Where((element) => element.PotentialValues.Count == size);

            foreach (var element in iterable)
            {
                List<string> potentials = element.PotentialValues;
                foreach (var potential in potentials)
                {
                    element.Value = potential;
                    element.PotentialValues = new List<string>();

                    List<Field> newList = new List<Field>();

                    foreach (Field s in fields)
                        newList.Add(s.Copy());

                    stack.Add(newList);
                }
            }
        }

        int GetNextPotentialSize(List<Field> fields)
        {
            int? smallest = null;
            foreach (Field s in fields)
            {
                if (s.HasValue) 
                    continue;

                // TODO: Magic numbers
                if (smallest == null && s.PotentialValues.Count != 0)
                {
                    smallest = s.PotentialValues.Count;
                }
                // TODO: Magic numbers
                if (smallest != null && s.PotentialValues.Count < smallest && s.PotentialValues.Count != 0)
                {
                    smallest = s.PotentialValues.Count;
                }
            }
            return smallest ?? 0;
        }
    }
}
