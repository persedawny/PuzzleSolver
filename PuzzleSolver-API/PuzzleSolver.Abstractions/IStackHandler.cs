using System.Collections.Generic;

namespace PuzzleSolver.Abstractions
{
    public interface IStackHandler<TField>
    {
        List<TField> GetFirstOnStack();
        void Trash();
        void CreateStack(List<TField> fields);
    }
}
