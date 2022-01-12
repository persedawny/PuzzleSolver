using MongoDB.Driver;
using PuzzleSolver.Abstractions;
using PuzzleSolver.Models.Entities;

namespace PuzzleSolver.DB
{
    internal class PuzzleCollectionProvider : ICollectionProvider<PuzzleEntity>
    {
        private const string ConnectionString = "mongodb://localhost:27017";
        private const string DatabaseNaam = "PuzzleSolver";
        private const string Collection = "Puzzles";

        private IMongoClient GetClient => new MongoClient(ConnectionString);

        public IMongoCollection<PuzzleEntity> GetCollection()
        {
            var database = GetClient.GetDatabase(DatabaseNaam);
            return database.GetCollection<PuzzleEntity>(Collection);
        }
    }
}
