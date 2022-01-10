using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PuzzleSolver.Models.Entities
{
    public class PuzzleEntity
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("Type")]
        public PuzzleEntityType Type { get; set; }

        [BsonElement("Json")]
        public string Json { get; set; }

        public PuzzleEntity()
        {
            Id = ObjectId.GenerateNewId();
        }
    }
}
