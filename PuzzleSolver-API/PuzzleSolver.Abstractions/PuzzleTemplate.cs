using System.Collections.Generic;
using System.Linq;

namespace PuzzleSolver.Abstractions
{
    public abstract class PuzzleTemplate
    {
        public List<PuzzleFieldTemplate> Fields;

        protected PuzzleTemplate(List<PuzzleFieldTemplate> fields)
        {
            this.Fields = fields;
        }

        public abstract string GetContentAsJson();
        public abstract PuzzleTemplate GetFromJson(string json);
        public abstract void SetIndexes();
        public abstract void LoopAndGetPotentialValues();
        public bool AllFieldsHaveValue => !Fields.Any(f => !f.HasValue);
        public bool HasFieldsWithOnePotential => Fields.Any(f => f.PotentialValues.Count == 1);
    }
}
