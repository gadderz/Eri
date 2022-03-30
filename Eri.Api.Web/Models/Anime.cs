using System.Collections.ObjectModel;

namespace Eri.Api.Web.Models;

public class Anime
{
    public string Id { get; set; }
    public string Name { get; set; }
    public Collection<Core.Models.Character> Characters { get; set; }

    public static implicit operator Core.Models.Anime(Anime source)
    {
        return new Core.Models.Anime()
        {
            Id = source.Id,
            Name = source.Name,
            Characters = source.Characters
        };
    }

    public static implicit operator Anime(Core.Models.Anime source)
    {
        return new Anime()
        {
            Id = source.Id,
            Name = source.Name,
            Characters = source.Characters
        };
    }
}