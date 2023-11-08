using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.Core.Common
{
    public abstract class Entity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; protected set; }

        public Entity()
        {
            Id = ObjectId.GenerateNewId().ToString();
        }
    }
}
