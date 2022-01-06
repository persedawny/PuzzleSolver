using MongoDB.Driver;
using PuzzleSolver.Abstractions;

namespace PuzzleSolver.DB
{
    internal class ConnectionProvider : IConnectionProvider
    {
        private const string ConnectionString = "mongodb://localhost:27017";
        private static IMongoClient instance = new MongoClient(ConnectionString);

        public IMongoClient GetMongoClient() => instance;
    }
}
