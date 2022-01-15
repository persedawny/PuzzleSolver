using MongoDB.Driver;
using PuzzleSolver.Abstractions;
using PuzzleSolver.Models.Entities;

namespace PuzzleSolver.DB
{
    internal class PuzzleCollectionProvider : ICollectionProvider<PuzzleEntity>
    {
        private const string connectionString = "mongodb://localhost:27017";
        private const string databaseNaam = "PuzzleSolver";
        private const string collection = "Puzzles";

        private IMongoClient getClient => new MongoClient(connectionString);

        public IMongoCollection<PuzzleEntity> GetCollection()
        {
            var database = getClient.GetDatabase(databaseNaam);
            return database.GetCollection<PuzzleEntity>(collection);
        }
    }
}
