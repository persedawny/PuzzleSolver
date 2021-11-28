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

        void CheckRow(SudokuField s)
        {
            for (int i = 0; i < fields.Count; i++)
            {
                SudokuField compared = fields[i];
                // TODO: if statement wegstoppen in een propperty?
                if ((compared.GetRowID() == s.GetRowID()) && compared.Value != null && s.PotentialValues.Contains(compared.Value.Value))
                {
                    s.PotentialValues.Remove(compared.Value.Value);
                    continue;
                }
            }
        }

        void CheckColumn(SudokuField s)
        {
            for (int i = 0; i < fields.Count; i++)
            {
                SudokuField compared = fields[i];
                // TODO: if statement wegstoppen in een propperty?
                if ((compared.GetColumnID() == s.GetColumnID()) && compared.Value != null && s.PotentialValues.Contains(compared.Value.Value))
                {
                    s.PotentialValues.Remove(compared.Value.Value);
                    continue;
                }
            }
        }

        void CheckBox(SudokuField s)
        {
            for (int i = 0; i < fields.Count; i++)
            {
                SudokuField compared = fields[i];
                if ((compared.GetBlockID() == s.GetBlockID()) &&
                    compared.Value != null &&
                    s.PotentialValues.Contains(compared.Value.Value))
                {
                    s.PotentialValues.Remove(compared.Value.Value);
                    continue;
                }
            }
        }

        void LoopAndGetPotentialValues()
        {
            for (int i = 0; i < fields.Count; i++)
            {
                SudokuField s = fields[i];
                if (s.Value == null)
                {
                    CheckBox(s);
                    CheckColumn(s);
                    CheckRow(s);
                }
            }
        }

        void FillInSimpleSquares()
        {
            for (int i = 0; i < fields.Count; i++)
            {
                SudokuField s = fields[i];

                if (s.Value == null && s.PotentialValues.Count == 1)
                {
                    s.Value = s.PotentialValues.First();
                    s.PotentialValues.RemoveAt(0);
                }
            }
        }

        bool CheckForPotentialsOne()
        {
            bool found = false;
            foreach (SudokuField s in fields)
            {
                if (s.PotentialValues.Count == 1)
                {
                    found = true;
                    break;
                }
            }
            return found;
        }

        void CreateStack()
        {
            int size = GetNextPotentialSize();
            if (size == 0)
            {
                Trash();
            }
            else
            {
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

                        stack.Add(newList.ToList());
                    }
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
            foreach (SudokuField s in fields)
            {
                if (s.Value != null)
                {
                    continue;
                }
                else
                {
                    return false;
                }
            }

            foreach (SudokuField s in fields)
            {
                if (!IsSolved(s))
                {
                    Trash();
                    return false;
                }
            }

            return true;
        }

        bool IsSolved(SudokuField square)
        {
            foreach (SudokuField s in fields)
            {
                if (s.Index != square.Index)
                {
                    if (s.GetColumnID() == square.GetColumnID())
                    {
                        if (s.Value == square.Value)
                        {
                            return false;
                        }
                    }

                    if (s.GetRowID() == square.GetRowID())
                    {
                        if (s.Value == square.Value)
                        {
                            return false;
                        }
                    }

                    if (s.GetBlockID() == square.GetBlockID())
                    {
                        if (s.Value == square.Value)
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

                if (CheckForPotentialsOne())
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

                if (fields[i].Value == null)
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
