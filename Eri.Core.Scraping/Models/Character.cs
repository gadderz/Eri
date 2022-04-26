using System.Text.Json.Serialization;

namespace Eri.Core.Scraping.Models;

public class Character
{
    [JsonPropertyName("mal_id")]
    public uint Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("name_kanji")]
    public string NameKanji { get; set; }

    [JsonPropertyName("about")]
    public string About { get; set; }

    [JsonPropertyName("role")]
    public string Role { get; set; }

    [JsonPropertyName("anime")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Anime Anime { get; set; }
}
