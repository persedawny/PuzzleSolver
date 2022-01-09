using MongoDB.Driver;
using PuzzleSolver.Abstractions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PuzzleSolver.Models.Entities;
using PuzzleSolver.Models.DTO;
using PuzzleSolver.Core.Converters;

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
                Json = new JsonConverter<IEnumerable<PuzzleFieldDTO>>().Convert(dtoList),
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
