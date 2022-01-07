using MongoDB.Driver;

namespace PuzzleSolver.Abstractions
{
    public interface IConnectionProvider<T>
    {
        IMongoCollection<T> GetCollection();
    }
}
