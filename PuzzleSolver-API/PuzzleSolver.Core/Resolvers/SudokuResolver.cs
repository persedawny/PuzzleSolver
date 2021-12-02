using PuzzleSolver.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PuzzleSolver.Core.Resolvers
{
    internal class SudokuResolver : ResolverTemplate<SudokuField>
    {
        private List<List<SudokuField>> stack = new List<List<SudokuField>>();

        public override bool IsResolved(List<SudokuField> puzzlefields)
        {
            foreach (SudokuField field in puzzlefields)
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

            foreach (SudokuField field in puzzlefields)
            {
                if (!FieldIsDone(puzzlefields, field))
                {
                    Trash();
                    return false;
                }
            }

            return true;
        }

        public override string Resolve(List<SudokuField> puzzleFields)
        {
            SetIndexes(puzzleFields);
            DateTime startTime = DateTime.Now;

            while (!IsResolved(puzzleFields))
            {
                LoopAndGetPotentialValues(puzzleFields);

                if (puzzleFields.Select(f => f.PotentialValues.Count == 1).Contains(true))
                {
                    FillInSimpleSquares(puzzleFields);
                }
                else
                {
                    CreateStack(puzzleFields);
                    puzzleFields = stack.First();
                }
            }

            DateTime endTime = DateTime.Now;

            var spentMinutes = (endTime - startTime).Minutes;
            var spentSeconds = (endTime - startTime).Seconds;
            var spentMiliseconds = (endTime - startTime).Milliseconds;

            return $"SOLVED IN {spentMinutes} MINUTES; {spentSeconds} SECONDS AND {spentMiliseconds} MILISECONDS";
        }

        bool FieldIsDone(List<SudokuField> fields, SudokuField field)
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

        void FillInSimpleSquares(List<SudokuField> fields)
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

        void SetIndexes(List<SudokuField> fields)
        {
            for (int i = 0; i < fields.Count; i++)
            {
                SudokuField s = fields[i];
                s.Index = i;
            }
        }

        void LoopAndGetPotentialValues(List<SudokuField> fields)
        {
            foreach (var field in fields)
            {
                if (field.HasValue) continue;

                foreach (var compareField in fields)
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

        void CreateStack(List<SudokuField> fields)
        {
            int size = GetNextPotentialSize(fields);

            if (size == 0)
            {
                Trash();
                return;
            }

            IEnumerable<SudokuField> iterable = fields.Where((element) => element.PotentialValues.Count == size);

            foreach (var element in iterable)
            {
                List<int> potentials = element.PotentialValues;
                foreach (int potential in potentials)
                {
                    element.Value = potential;
                    element.PotentialValues = new List<int>();

                    List<SudokuField> newList = new List<SudokuField>();

                    foreach (SudokuField s in fields)
                        newList.Add(s.Copy());

                    stack.Add(newList);
                }
            }
        }

        int GetNextPotentialSize(List<SudokuField> fields)
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
