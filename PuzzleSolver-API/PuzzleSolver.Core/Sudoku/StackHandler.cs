using PuzzleSolver.Abstractions;
using PuzzleSolver.Core.Exceptions;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace PuzzleSolver.Core.Sudoku
{
    internal class StackHandler : IStackHandler<Field>
    {
        private List<List<Field>> stack = new List<List<Field>>();

        public void AddToStack(List<Field> fields) => stack.Add(fields);
        private bool HasItemsOnStack => stack.Any();

        public List<Field> GetFirstOnStack()
        {
            if (!HasItemsOnStack)
                throw new UnsolvablePuzzleException();

            return stack.FirstOrDefault();
        }

        public void Trash()
        {
            if (!HasItemsOnStack)
                throw new UnsolvablePuzzleException();

            stack.RemoveAt(0);

            Debug.WriteLine(stack.Count);
        }

        public void CreateStack(List<Field> fields)
        {
            int size = GetNextPotentialSize(fields);

            if (size == 0)
            {
                Trash();
                return;
            }

            IEnumerable<Field> iterable = fields.Where((element) => element.PotentialValues.Count == size);

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

            Debug.WriteLine(stack.Count);
        }

        private int GetNextPotentialSize(List<Field> fields)
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
