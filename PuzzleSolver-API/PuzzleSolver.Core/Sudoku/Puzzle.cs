using PuzzleSolver.Abstractions;
using PuzzleSolver.Core.Converters;
using System.Collections.Generic;

namespace PuzzleSolver.Core.Sudoku
{
    class Puzzle : PuzzleTemplate
    {
        public new List<Field> fields = new();
        public Puzzle(List<PuzzleField> items) : base(items) {
            fields = FieldMapper.MapListToImplementation(items);
        }

        public override string GetContentAsJson() => new JsonConverter<Puzzle>().Convert(this);

        public override PuzzleTemplate GetFromJson(string json) => new JsonConverter<Puzzle>().Deserialize(json);

        public override void SetIndexes()
        {
            int index = 0;
            foreach (var field in fields)
            {
                field.Index = index;
                index++;
            }
        }

        public override void LoopAndGetPotentialValues()
        {
            foreach (Field field in fields)
            {
                if (field.HasValue) continue;

                foreach (Field compareField in fields)
                {
                    /*
                     * Lege velden, niet gerelateerde velden en getallen
                     * die niet in de Potentials voorkomen overslaan!
                     */

                    if (!compareField.HasValue)
                        continue;

                    if (!field.IsRelatedTo(compareField))
                        continue;

                    if (!field.PotentialValues.Contains(compareField.Value))
                        continue;

                    field.PotentialValues.Remove(compareField.Value);
                }
            }
        }
    }
}
