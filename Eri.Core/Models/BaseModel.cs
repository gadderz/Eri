using Eri.MongoDB.Interfaces;
using MongoDB.Bson.Serialization.Attributes;

namespace Eri.Core.Models;

public abstract class BaseModel : IEntity
{
    public string Id { get; set; }
    public DateTime CreatedAt { get; set; }
    [BsonIgnoreIfDefault]
    public DateTime? UpdatedAt { get; set; }
}

public abstract class BaseModel<TId> : IEntity<TId> where TId : IComparable<TId>, IEquatable<TId>
{
    public TId Id { get; set; }
    public DateTime CreatedAt { get; set; }
    [BsonIgnoreIfDefault]
    public DateTime? UpdatedAt { get; set; }
}
