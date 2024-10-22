﻿using System.Text.Json.Serialization;

namespace Eri.Api.Web.Models;

public class Character
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Anime Anime { get; set; }

    public static explicit operator Core.Models.Character(Character source)
    {
        return new Core.Models.Character()
        {
            Id = source.Id,
            Name = source.Name,
            Anime = (Core.Models.Anime)source.Anime
        };
    }

    public static explicit operator Character(Core.Models.Character source)
    {
        return new Character()
        {
            Id = source.Id,
            Name = source.Name,
            Anime = (Anime)source.Anime
        };
    }
}
