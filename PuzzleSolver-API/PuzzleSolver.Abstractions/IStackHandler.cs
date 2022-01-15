using System.Collections.Generic;

namespace PuzzleSolver.Abstractions
{
    public interface IStackHandler<TField> where TField : PuzzleFieldTemplate
    {
        List<TField> GetFirstOnStack();
        void Trash();
        void CreateStack(List<TField> fields);
    }
}
