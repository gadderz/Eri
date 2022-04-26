using System;
using System.Text.Json.Serialization;

namespace Eri.Core.Scraping.Models;

public class Response<TData>
{
    [JsonPropertyName("data")]
    public TData Data { get; set; }

    [JsonPropertyName("pagination")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Pagination Pagination { get; set; }
}
