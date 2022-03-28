using Eri.MongoDB.Interfaces;
using MongoDB.Bson.Serialization.Attributes;

namespace Eri.Core.Models
{
    public abstract class BaseModel : IEntity
    {
        public string Id { get; set; }
        public DateTime CreatedAt { get; set; }
        [BsonIgnoreIfDefault]
        public DateTime? UpdatedAt { get; set; }
    }
}
