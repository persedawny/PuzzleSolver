using MongoDB.Driver;
using PuzzleSolver.Abstractions;
using PuzzleSolver.DB.Repositories.Puzzle;
using System.Threading.Tasks;

namespace PuzzleSolver.DB.Repositories
{
    internal class PuzzleRepository : IRepository<PuzzleEntity>
    {
        private readonly IMongoCollection<PuzzleEntity> Collection;

        public PuzzleRepository(IConnectionProvider<PuzzleEntity> connectionProvider)
        {
            Collection = connectionProvider.GetCollection();
        }

        public Task AddAsync(PuzzleEntity item) => Collection.InsertOneAsync(item);

        public async Task RemoveAsync(PuzzleEntity item)
        {
            var deleteFilter = Builders<PuzzleEntity>.Filter.Eq("Id", item.Id);
            await Collection.DeleteOneAsync(deleteFilter);
        }

        public async Task UpdateAsync(PuzzleEntity item)
        {
            var filter = Builders<PuzzleEntity>.Filter.Eq("Id", item.Id);
            var update = Builders<PuzzleEntity>.Update.Set("Json", item.Json);
            await Collection.UpdateOneAsync(filter, update);
        }
    }
}
