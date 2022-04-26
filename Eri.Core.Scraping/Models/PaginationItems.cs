using System;
using System.Text.Json.Serialization;

namespace Eri.Core.Scraping.Models;

public class PaginationItems
{
    [JsonPropertyName("count")]
    public uint Count { get; set; }

    [JsonPropertyName("total")]
    public uint Total { get; set; }

    [JsonPropertyName("per_page")]
    public uint PerPage { get; set; }
}
