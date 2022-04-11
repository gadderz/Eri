using System;
using System.Text.Json.Serialization;

namespace Eri.Core.Scraping.Models;

public class Response<T>
{
    [JsonPropertyName("data")]
    public T Data { get; set; }
    [JsonPropertyName("pagination")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Pagination Pagination { get; set; }
}
