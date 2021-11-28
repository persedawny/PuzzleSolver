using PuzzleSolver.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PuzzleSolver.Core.PuzzleTemplates
{
    internal class SudokuTemplate : PuzzleTemplate
    {
        List<SudokuField> items = new List<SudokuField>();
        List<List<SudokuField>> stack = new List<List<SudokuField>>();

        public SudokuTemplate(List<SudokuField> items)
        {
            this.items = items;
        }

        void SetIndexes()
        {
            for (int i = 0; i < items.Count; i++)
            {
                SudokuField s = items[i];
                s.index = i;
            }
        }

        void CheckRow(SudokuField s)
        {
            for (int i = 0; i < items.Count; i++)
            {
                SudokuField compared = items[i];
                // TODO: if statement wegstoppen in een propperty?
                if ((compared.GetRowID() == s.GetRowID()) && compared.value != null && s.potentialValues.Contains(compared.value.Value))
                {
                    s.potentialValues.Remove(compared.value.Value);
                    continue;
                }
            }
        }

        void CheckColumn(SudokuField s)
        {
            for (int i = 0; i < items.Count; i++)
            {
                SudokuField compared = items[i];
                // TODO: if statement wegstoppen in een propperty?
                if ((compared.GetColumnID() == s.GetColumnID()) && compared.value != null && s.potentialValues.Contains(compared.value.Value))
                {
                    s.potentialValues.Remove(compared.value.Value);
                    continue;
                }
            }
        }

        void CheckBox(SudokuField s)
        {
            for (int i = 0; i < items.Count; i++)
            {
                SudokuField compared = items[i];
                if ((compared.GetBlockID() == s.GetBlockID()) &&
                    compared.value != null &&
                    s.potentialValues.Contains(compared.value.Value))
                {
                    s.potentialValues.Remove(compared.value.Value);
                    continue;
                }
            }
        }

        void LoopAndGetPotentialValues()
        {
            for (int i = 0; i < items.Count; i++)
            {
                SudokuField s = items[i];
                if (s.value == null)
                {
                    CheckBox(s);
                    CheckColumn(s);
                    CheckRow(s);
                }
            }
        }

        void FillInSimpleSquares()
        {
            for (int i = 0; i < items.Count; i++)
            {
                SudokuField s = items[i];

                if (s.value == null && s.potentialValues.Count == 1)
                {
                    s.value = s.potentialValues.First();
                    s.potentialValues.RemoveAt(0);
                }
            }
        }

        bool CheckForPotentialsOne()
        {
            bool found = false;
            foreach (SudokuField s in items)
            {
                if (s.potentialValues.Count == 1)
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
                IEnumerable<SudokuField> iterable = items.Where((element) => element.potentialValues.Count == size);

                foreach (var element in iterable)
                {
                    List<int> potentials = element.potentialValues;
                    foreach (int potential in potentials)
                    {
                        element.value = potential;
                        element.potentialValues = new List<int>();
                        List<SudokuField> newList = new List<SudokuField>();

                        foreach (SudokuField s in items)
                            newList.Add(s.Copy());

                        stack.Add(newList.ToList());
                    }
                }
            }
        }

        int GetNextPotentialSize()
        {
            int? smallest = null;
            foreach (SudokuField s in items)
            {
                // TODO: Magic numbers
                if (smallest == null && s.potentialValues.Count != 0)
                {
                    smallest = s.potentialValues.Count;
                }
                // TODO: Magic numbers
                if (smallest != null && s.potentialValues.Count < smallest && s.potentialValues.Count != 0)
                {
                    smallest = s.potentialValues.Count;
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
            foreach (SudokuField s in items)
            {
                if (s.value != null)
                {
                    continue;
                }
                else
                {
                    return false;
                }
            }

            foreach (SudokuField s in items)
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
            foreach (SudokuField s in items)
            {
                if (s.index != square.index)
                {
                    if (s.GetColumnID() == square.GetColumnID())
                    {
                        if (s.value == square.value)
                        {
                            return false;
                        }
                    }

                    if (s.GetRowID() == square.GetRowID())
                    {
                        if (s.value == square.value)
                        {
                            return false;
                        }
                    }

                    if (s.GetBlockID() == square.GetBlockID())
                    {
                        if (s.value == square.value)
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
                    items = stack.First();
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
            for (int i = 0; i < items.Count; i++)
            {
                if (i % 9 == 0)
                {
                    System.Diagnostics.Debug.WriteLine(string.Empty);
                }

                if (items[i].value == null)
                {
                    System.Diagnostics.Debug.Write("  ");
                }
                else
                {
                    System.Diagnostics.Debug.Write($" {items[i].value}");
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
