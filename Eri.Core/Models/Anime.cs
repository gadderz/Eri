using MongoDB.Bson.Serialization.Attributes;
using System.Collections.ObjectModel;

namespace Eri.Core.Models;

public class Anime : BaseModel
{
    [BsonRequired]
    public string Name { get; set; }

    [BsonRequired]
    public Collection<Character> Characters { get; set; } = new Collection<Character>();
}