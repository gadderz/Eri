using System.Text.Json.Serialization;

namespace Eri.Core.Scraping.Models;

public class Anime
{
    [JsonPropertyName("mal_id")]
    public uint Id { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("title_english")]
    public string TitleEnglish { get; set; }

    [JsonPropertyName("title_japanese")]
    public string TitleJapanese { get; set; }

    [JsonPropertyName("synopsis")]
    public string Synopsis { get; set; }

    [JsonPropertyName("year")]
    public int Year { get; set; }

    [JsonPropertyName("season")]
    public string Season { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }
}
