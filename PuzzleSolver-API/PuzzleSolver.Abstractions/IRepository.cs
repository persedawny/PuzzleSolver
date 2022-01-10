using System.Collections.Generic;
using System.Threading.Tasks;

namespace PuzzleSolver.Abstractions
{
    public interface IRepository<T>
    {
        Task<IEnumerable<string>> GetAllPuzzleNamesAsync();
        Task AddFromDtoListAsync(IEnumerable<PuzzleFieldDTO> dtoList, PuzzleEntityType type);
        Task RemoveAsync(T item);
        Task UpdateAsync(T item);
    }
}
