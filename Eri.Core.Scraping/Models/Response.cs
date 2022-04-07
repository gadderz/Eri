using System;
using System.Text.Json.Serialization;

namespace Eri.Core.Scraping.Models;

public class Response<T>
{
    public T Data { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Pagination Pagination { get; set; }
}
