using MongoDB.Driver;
using PuzzleSolver.Abstractions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PuzzleSolver.DB.Repositories
{
    internal class PuzzleRepository : IRepository<PuzzleEntity>
    {
        private readonly IMongoCollection<PuzzleEntity> Collection;

        public PuzzleRepository(ICollectionProvider<PuzzleEntity> connectionProvider)
        {
            Collection = connectionProvider.GetCollection();

        }

        public async Task AddFromDtoListAsync(IEnumerable<PuzzleFieldDTO> dtoList, PuzzleEntityType type)
        {
            var item = new PuzzleEntity()
            {
                Json = JsonConvert.SerializeObject(dtoList),
                Type = type
            };

            await Collection.InsertOneAsync(item);
        }

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
