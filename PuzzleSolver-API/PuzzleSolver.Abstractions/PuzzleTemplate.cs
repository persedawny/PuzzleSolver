using System.Collections.Generic;
using System.Linq;

namespace PuzzleSolver.Abstractions
{
    public abstract class PuzzleTemplate
    {
        private List<PuzzleFieldTemplate> fields;
        public List<PuzzleFieldTemplate> Fields
        {
            get { return fields; }
            set { fields = value; }
        }

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
