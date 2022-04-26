using System;
using System.Text.Json.Serialization;

namespace Eri.Core.Scraping.Models;

public class CharacterPictures
{
    [JsonPropertyName("jpg")]
    public Jpg Jpg { get; set; }
}

public class Jpg
{
    [JsonPropertyName("image_url")]
    public string ImageUrl { get; set; }
}