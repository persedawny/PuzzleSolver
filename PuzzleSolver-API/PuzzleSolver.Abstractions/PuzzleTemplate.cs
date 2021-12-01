using System.Collections.Generic;

namespace PuzzleSolver.Abstractions
{
    public abstract class PuzzleTemplate<T> where T : PuzzleField
    {
        public List<T> fields;

        public abstract string GetContentAsJson();
        public abstract void SetContentFromJson(string json);
    }
}
