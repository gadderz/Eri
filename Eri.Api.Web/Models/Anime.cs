using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace Eri.Api.Web.Models;

public class Anime
{
    public string Id { get; set; }
    public string Name { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Collection<Character> Characters { get; set; }

    public static explicit operator Core.Models.Anime(Anime source)
    {
        var res = new Core.Models.Anime();
        res.Id = source.Id;
        res.Name = source.Name;

        foreach (var character in source.Characters)
            res.Characters.Add((Core.Models.Character)character);

        return res;
    }

    public static explicit operator Anime(Core.Models.Anime source)
    {
        var res = new Anime();
        res.Id = source.Id;
        res.Name = source.Name;

        foreach (var character in source.Characters)
            res.Characters.Add((Character)character);

        return res;
    }
}