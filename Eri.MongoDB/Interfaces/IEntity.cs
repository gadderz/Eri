using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Eri.MongoDB.Interfaces;

public interface IEntity : IEntity<string>
{
}

public interface IEntity<TId> where TId : IComparable<TId>, IEquatable<TId>
{
    [BsonId]
    TId Id { get; set; }
}
