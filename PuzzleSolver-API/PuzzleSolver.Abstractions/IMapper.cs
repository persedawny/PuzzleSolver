using System.Collections.Generic;

namespace PuzzleSolver.Abstractions
{
    public interface IMapper<TField>
    {
        List<TField> MapListToImplementation(List<PuzzleField> fields);
        List<PuzzleField> MapListToAbstraction(List<TField> fields);
    }
}
