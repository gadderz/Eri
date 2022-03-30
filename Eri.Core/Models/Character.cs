using MongoDB.Bson.Serialization.Attributes;

namespace Eri.Core.Models;

public class Character : BaseModel<Guid>
{
    [BsonRequired]
    public string Name { get; set; }
    [BsonRequired]
    public char Gender { get; set; }
    [BsonIgnore]
    public Anime Anime { get; set; }
}
