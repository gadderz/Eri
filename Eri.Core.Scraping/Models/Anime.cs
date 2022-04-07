using System.Text.Json.Serialization;

namespace Eri.Core.Scraping.Models;

public class Anime
{
    [JsonPropertyName("mal_id")]
    public uint Id { get; set; }
    public string Title { get; set; }
    [JsonPropertyName("title_english")]
    public string TitleEnglish { get; set; }
    [JsonPropertyName("title_japanese")]
    public string TitleJapanese { get; set; }
    public string Synopsis { get; set; }
    public int Year { get; set; }
    public string Season { get; set; }
}
