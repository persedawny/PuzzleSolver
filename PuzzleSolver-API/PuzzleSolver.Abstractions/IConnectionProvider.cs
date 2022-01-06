using MongoDB.Driver;

namespace PuzzleSolver.Abstractions
{
    public interface IConnectionProvider
    {
        IMongoClient GetMongoClient();
    }
}
