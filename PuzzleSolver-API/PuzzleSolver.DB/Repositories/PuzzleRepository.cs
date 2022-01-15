using MongoDB.Driver;
using PuzzleSolver.Abstractions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PuzzleSolver.Models.Entities;
using PuzzleSolver.Models.DTO;
using PuzzleSolver.Core.Converters;
using System.Linq;
using MongoDB.Bson;

namespace PuzzleSolver.DB.Repositories
{
    internal class PuzzleRepository : IRepository<PuzzleEntity>
    {
        private readonly IMongoCollection<PuzzleEntity> collection;

        public PuzzleRepository(ICollectionProvider<PuzzleEntity> connectionProvider)
        {
            collection = connectionProvider.GetCollection();
        }

        public async Task AddFromDtoListAsync(IEnumerable<PuzzleFieldDTO> dtoList, PuzzleEntityType type)
        {
            var item = new PuzzleEntity()
            {
                Json = new JsonConverter<IEnumerable<PuzzleFieldDTO>>().Convert(dtoList),
                Type = type
            };

            await collection.InsertOneAsync(item);
        }

        public async Task<IEnumerable<string>> GetAllPuzzleNamesAsync()
        {
            var allQuery = collection.Find(_ => true);
            var documents = await allQuery.ToListAsync();
            return documents.Select(x => x.Id.ToString()).ToList(); ;
        }

        public async Task<string> GetPuzzleJsonByIDAsync(string id)
        {
            var findFilter = Builders<PuzzleEntity>.Filter.Eq("Id", ObjectId.Parse(id));
            var result = await collection.Find(findFilter).FirstOrDefaultAsync();
            return result.Json;
        }

        public async Task RemoveAsync(PuzzleEntity item)
        {
            var deleteFilter = Builders<PuzzleEntity>.Filter.Eq("Id", item.Id);
            await collection.DeleteOneAsync(deleteFilter);
        }

        public async Task UpdateAsync(PuzzleEntity item)
        {
            var filter = Builders<PuzzleEntity>.Filter.Eq("Id", item.Id);
            var update = Builders<PuzzleEntity>.Update.Set("Json", item.Json);
            await collection.UpdateOneAsync(filter, update);
        }
    }
}
