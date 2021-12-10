using System.Collections.Generic;
using System.Linq;

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
        public abstract void SetIndexes();
        public abstract void LoopAndGetPotentialValues();
        public bool AllFieldsHaveValue => !fields.Any(f => !f.HasValue);
        public bool HasFieldsWithOnePotential => fields.Any(f => f.PotentialValues.Count == 1);
        public void notify(List<PuzzleField> f)
        {
            fields = f;
        }
    }
}
