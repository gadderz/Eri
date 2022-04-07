using System.Text.Json.Serialization;

namespace Eri.Core.Scraping.Models;

public class Pagination
{
    [JsonPropertyName("last_visible_page")]
    public uint LastVisiblePage { get; set; }
    [JsonPropertyName("has_next_page")]
    public bool HasNextPage { get; set; }
}
