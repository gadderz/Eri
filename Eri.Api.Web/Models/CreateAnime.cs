using Eri.Core.Models;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Eri.Api.Web.Models;

public class CreateAnime
{
    [Required]
    public string Name { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Collection<Character> Characters { get; set; }

    public static implicit operator Anime(CreateAnime source)
    {
        var convert = new Anime();

        convert.Name = source.Name;
        convert.Characters = source.Characters;

        return convert;
    }
}