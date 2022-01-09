using MongoDB.Driver;
using PuzzleSolver.Abstractions;

namespace PuzzleSolver.DB
{
    internal class PuzzleCollectionProvider : ICollectionProvider<PuzzleEntity>
    {
        private const string ConnectionString = "mongodb://localhost:27017";
        private const string DatabaseNaam = "PuzzleSolver";
        private const string Collection = "Puzzles";
        private static IMongoClient client;

        public PuzzleCollectionProvider()
        {
            client = new MongoClient(ConnectionString);
        }

        public IMongoCollection<PuzzleEntity> GetCollection()
        {
            var database = client.GetDatabase(DatabaseNaam);
            return database.GetCollection<PuzzleEntity>(Collection);
        }
    }
}
