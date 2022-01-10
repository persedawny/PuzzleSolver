using PuzzleSolver.Models.DTO;
using PuzzleSolver.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PuzzleSolver.Abstractions
{
    public interface IRepository<T>
    {
        Task<IEnumerable<string>> GetAllPuzzleNamesAsync();
        Task<string> GetPuzzleJsonByIDAsync(string id);
        Task AddFromDtoListAsync(IEnumerable<PuzzleFieldDTO> dtoList, PuzzleEntityType type);
        Task RemoveAsync(T item);
        Task UpdateAsync(T item);
        
    }
}
