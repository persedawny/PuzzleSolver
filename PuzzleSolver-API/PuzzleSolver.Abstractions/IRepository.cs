using System.Threading.Tasks;

namespace PuzzleSolver.Abstractions
{
    public interface IRepository<T>
    {
        Task AddAsync(T item);
        Task RemoveAsync(T item);
        Task UpdateAsync(T item);
    }
}
