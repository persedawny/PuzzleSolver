using System;
using System.Collections.Generic;

namespace PuzzleSolver.Abstractions
{
    public abstract class PuzzleTemplate
    {
        public List<PuzzleField> fields;

        protected PuzzleTemplate(List<PuzzleField> fields)
        {
            this.fields = fields;
        }

        public abstract string GetContentAsJson();
        public abstract PuzzleTemplate GetFromJson(string json);
    }
}
