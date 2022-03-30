namespace Eri.Api.Web.Models;

public class Character
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public char Gender { get; set; }
    public Anime Anime { get; set; }

    public static implicit operator Core.Models.Character(Character source)
    {
        return new Core.Models.Character()
        {
            Id = source.Id,
            Name = source.Name,
            Gender = source.Gender
        };
    }

    public static implicit operator Character(Core.Models.Character source)
    {
        return new Character()
        {
            Id = source.Id,
            Name = source.Name,
            Gender = source.Gender,
            Anime = source.Anime
        };
    }
}
