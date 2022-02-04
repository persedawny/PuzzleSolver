using PuzzleSolver.Abstractions;
using PuzzleSolver.Models.Exceptions;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace PuzzleSolver.Core.Sudoku
{
    internal class StackHandler : IStackHandler<PuzzleFieldTemplate>
    {
        private List<List<PuzzleFieldTemplate>> stack = new List<List<PuzzleFieldTemplate>>();

        public void AddToStack(List<PuzzleFieldTemplate> fields) => stack.Add(fields);
        private bool hasItemsOnStack => stack.Any();

        public void Trash()
        {
            if (!hasItemsOnStack)
                throw new UnsolvablePuzzleException();

            stack.RemoveAt(0);
        }

        public void CreateStack(List<PuzzleFieldTemplate> fields)
        {
            int size = GetNextPotentialSize(fields);

            if (size == 0)
            {
                Trash();
                return;
            }

            IEnumerable<PuzzleFieldTemplate> iterable = fields.Where((element) => element.PotentialValues.Count == size);

            foreach (var element in iterable)
            {
                List<string> potentials = element.PotentialValues;
                foreach (var potential in potentials)
                {
                    element.Value = potential;
                    element.PotentialValues = new List<string>();

                    List<PuzzleFieldTemplate> newList = new List<PuzzleFieldTemplate>();

                    foreach (Field s in fields)
                        newList.Add(s.Copy());

                    stack.Add(newList);
                }
            }
        }

        private int GetNextPotentialSize(List<PuzzleFieldTemplate> fields)
        {
            int? smallest = null;
            foreach (Field s in fields)
            {
                if (s.HasValue)
                    continue;

                if (smallest == null && s.PotentialValues.Count != 0)
                {
                    smallest = s.PotentialValues.Count;
                }
                
                if (smallest != null && s.PotentialValues.Count < smallest && s.PotentialValues.Count != 0)
                {
                    smallest = s.PotentialValues.Count;
                }
            }
            return smallest ?? 0;
        }

        public List<PuzzleFieldTemplate> GetFirstOnStack()
        {
            if (!hasItemsOnStack)
                throw new UnsolvablePuzzleException();

            return stack.FirstOrDefault();
        }
    }
}
