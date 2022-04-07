using System.Text.Json.Serialization;

namespace Eri.Core.Scraping.Models;

public class Character
{
    [JsonPropertyName("mal_id")]
    public uint Id { get; set; }
}
