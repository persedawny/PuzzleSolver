using PuzzleSolver.Abstractions;
using PuzzleSolver.Core.PuzzleTemplates;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PuzzleSolver.Core.Resolvers
{
    internal class SudokuResolver : ResolverTemplate
    {
        private List<List<PuzzleField>> stack = new List<List<PuzzleField>>();

        public override bool IsResolved(PuzzleTemplate puzzle)
        {
            foreach (SudokuField field in puzzle.fields)
            {
                if (field.HasValue)
                {
                    continue;
                }
                else
                {
                    return false;
                }
            }

            foreach (SudokuField field in puzzle.fields)
            {
                if (!FieldIsDone(puzzle.fields, field))
                {
                    Trash();
                    return false;
                }
            }

            return true;
        }

        public override PuzzleTemplate Resolve(List<PuzzleField> fields)
        {
            var puzzle = new Sudoku(fields);
            SetIndexes(puzzle.fields);
            DateTime startTime = DateTime.Now;

            while (!IsResolved(puzzle))
            {
                LoopAndGetPotentialValues(puzzle.fields);

                if (puzzle.fields.Cast<SudokuField>().Select(f => f.PotentialValues.Count == 1).Contains(true))
                {
                    FillInSimpleSquares(puzzle.fields);
                }
                else
                {
                    CreateStack(puzzle.fields);
                    puzzle.fields = stack.First();
                }
            }

            DateTime endTime = DateTime.Now;

            var spentMinutes = (endTime - startTime).Minutes;
            var spentSeconds = (endTime - startTime).Seconds;
            var spentMiliseconds = (endTime - startTime).Milliseconds;

            return puzzle;
        }

        bool FieldIsDone(List<PuzzleField> fields, SudokuField field)
        {
            foreach (SudokuField s in fields)
            {
                if (s.Index != field.Index)
                {
                    if (s.GetColumnID() == field.GetColumnID())
                    {
                        if (s.Value == field.Value)
                        {
                            return false;
                        }
                    }

                    if (s.GetRowID() == field.GetRowID())
                    {
                        if (s.Value == field.Value)
                        {
                            return false;
                        }
                    }

                    if (s.GetBlockID() == field.GetBlockID())
                    {
                        if (s.Value == field.Value)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        void Trash()
        {
            stack.RemoveAt(0);
        }

        void FillInSimpleSquares(List<PuzzleField> fields)
        {
            foreach (SudokuField field in fields)
            {
                if (!field.HasValue && field.PotentialValues.Count == 1)
                {
                    field.Value = field.PotentialValues.First();
                    field.PotentialValues.RemoveAt(0);
                }
            }
        }

        void SetIndexes(List<PuzzleField> fields)
        {
            for (int i = 0; i < fields.Count; i++)
            {
                SudokuField s = fields[i] as SudokuField;
                s.Index = i;
            }
        }

        void LoopAndGetPotentialValues(List<PuzzleField> fields)
        {
            foreach (SudokuField field in fields)
            {
                if (field.HasValue) continue;

                foreach (SudokuField compareField in fields)
                {
                    /*
                     * Lege velden, niet gerelateerde velden en getallen
                     * die niet in de Potentials voorkomen overslaan!
                     */

                    if (!compareField.HasValue)
                        continue;

                    if (!field.IsRelatedTo(compareField))
                        continue;

                    if (!field.PotentialValues.Contains(compareField.Value.Value))
                        continue;

                    field.PotentialValues.Remove(compareField.Value.Value);
                }
            }
        }

        void CreateStack(List<PuzzleField> fields)
        {
            int size = GetNextPotentialSize(fields);

            if (size == 0)
            {
                Trash();
                return;
            }

            IEnumerable<SudokuField> iterable = fields.Cast<SudokuField>().Where((element) => element.PotentialValues.Count == size);

            foreach (var element in iterable)
            {
                List<int> potentials = element.PotentialValues;
                foreach (int potential in potentials)
                {
                    element.Value = potential;
                    element.PotentialValues = new List<int>();

                    List<PuzzleField> newList = new List<PuzzleField>();

                    foreach (SudokuField s in fields)
                        newList.Add(s.Copy());

                    stack.Add(newList);
                }
            }
        }

        int GetNextPotentialSize(List<PuzzleField> fields)
        {
            int? smallest = null;
            foreach (SudokuField s in fields)
            {
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
