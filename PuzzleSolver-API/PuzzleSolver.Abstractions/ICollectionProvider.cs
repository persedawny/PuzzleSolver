using MongoDB.Driver;

namespace PuzzleSolver.Abstractions
{
    public interface ICollectionProvider<T>
    {
        IMongoCollection<T> GetCollection();
    }
}
