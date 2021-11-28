using PuzzleSolver.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PuzzleSolver.Core.PuzzleTemplates
{
    internal class SudokuTemplate : PuzzleTemplate
    {
        private List<SudokuField> fields = new List<SudokuField>();
        private List<List<SudokuField>> stack = new List<List<SudokuField>>();

        public SudokuTemplate(List<SudokuField> items)
        {
            this.fields = items;
        }

        void SetIndexes()
        {
            for (int i = 0; i < fields.Count; i++)
            {
                SudokuField s = fields[i];
                s.Index = i;
            }
        }

        void CheckRow(SudokuField field, SudokuField compareField)
        {
            // TODO: if statement wegstoppen in een propperty?
            if ((compareField.GetRowID() == field.GetRowID()) && compareField.HasValue && field.PotentialValues.Contains(compareField.Value.Value))
                field.PotentialValues.Remove(compareField.Value.Value);
        }

        void CheckColumn(SudokuField field, SudokuField compareField)
        {
            // TODO: if statement wegstoppen in een propperty?
            if ((compareField.GetColumnID() == field.GetColumnID()) && compareField.HasValue && field.PotentialValues.Contains(compareField.Value.Value))
                field.PotentialValues.Remove(compareField.Value.Value);
        }

        void CheckBox(SudokuField field, SudokuField compareField)
        {
            // TODO: if statement wegstoppen in een propperty?
            if ((compareField.GetBlockID() == field.GetBlockID()) && compareField.HasValue && field.PotentialValues.Contains(compareField.Value.Value))
                field.PotentialValues.Remove(compareField.Value.Value);
        }

        void LoopAndGetPotentialValues()
        {
            foreach (var field in fields)
            {
                foreach (var compareField in fields)
                {
                    if (!field.HasValue)
                    {
                        CheckBox(field, compareField);
                        CheckColumn(field, compareField);
                        CheckRow(field, compareField);
                    }
                }
            }
        }

        void FillInSimpleSquares()
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

        bool HasFieldsWithOnePotential() => fields.Select(f => f.PotentialValues.Count == 1).Contains(true);

        void CreateStack()
        {
            int size = GetNextPotentialSize();

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

        int GetNextPotentialSize()
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

        void Trash()
        {
            stack.RemoveAt(0);
        }

        bool IsDone()
        {
            foreach (SudokuField field in fields)
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

            foreach (SudokuField field in fields)
            {
                if (!IsSolved(field))
                {
                    Trash();
                    return false;
                }
            }

            return true;
        }

        bool IsSolved(SudokuField field)
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

        void Solve()
        {
            bool done = false;
            SetIndexes();
            DateTime startTime = DateTime.Now;

            while (!done)
            {
                LoopAndGetPotentialValues();

                if (HasFieldsWithOnePotential())
                {
                    FillInSimpleSquares();
                }
                else
                {
                    CreateStack();
                    fields = stack.First();
                }

                done = IsDone();
            }

            DateTime endTime = DateTime.Now;

            var spentMinutes = (endTime - startTime).Minutes;
            var spentSeconds = (endTime - startTime).Seconds;
            var spentMiliseconds = (endTime - startTime).Milliseconds;

            System.Diagnostics.Debug.WriteLine($"SOLVED IN {spentMinutes} MINUTES; {spentSeconds} SECONDS AND {spentMiliseconds} MILISECONDS");
        }

        public void Resolve()
        {
            System.Diagnostics.Debug.WriteLine("TO SOLVE:");
            PrintPuzzle();
            Solve();
            System.Diagnostics.Debug.WriteLine("SOLUTION:");
            PrintPuzzle();
        }

        void PrintPuzzle()
        {
            for (int i = 0; i < fields.Count; i++)
            {
                if (i % 9 == 0)
                {
                    System.Diagnostics.Debug.WriteLine(string.Empty);
                }

                if (!fields[i].HasValue)
                {
                    System.Diagnostics.Debug.Write("  ");
                }
                else
                {
                    System.Diagnostics.Debug.Write($" {fields[i].Value}");
                }
            }

            System.Diagnostics.Debug.WriteLine(string.Empty);
        }

        public override string GetContentAsJson()
        {
            // TODO: Implement after unit tests
            throw new System.NotImplementedException();
        }

        public override void SetContentFromJson(string json)
        {
            // TODO: Implement after test
            throw new System.NotImplementedException();
        }
    }
}
