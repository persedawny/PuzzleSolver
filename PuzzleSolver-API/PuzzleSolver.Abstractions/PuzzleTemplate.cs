using System.Collections.Generic;
using System.Linq;

namespace PuzzleSolver.Abstractions
{
    public abstract class PuzzleTemplate
    {
        public List<PuzzleFieldTemplate> fields;

        protected PuzzleTemplate(List<PuzzleFieldTemplate> fields)
        {
            this.fields = fields;
        }

        public abstract string GetContentAsJson();
        public abstract PuzzleTemplate GetFromJson(string json);
        public abstract void SetIndexes();
        public abstract void LoopAndGetPotentialValues();
        public bool AllFieldsHaveValue => !fields.Any(f => !f.HasValue);
        public bool HasFieldsWithOnePotential => fields.Any(f => f.PotentialValues.Count == 1);
    }
}
