using Eri.Api.Web.Models;
using Eri.Api.Web.Validators;

namespace Eri.Api.Web;

public class Anime
{
    private readonly Core.Anime _animeService;

    public Anime(Core.Anime animeService)
    {
        _animeService = animeService;
    }

    public async Task<Response> InsertAsync(Models.Anime anime)
    {
        var validator = new CreateAnimeValidator();
        var validationResult = validator.Validate(anime);

        var response = new Response();

        if (!validationResult.IsValid)
        {
            response.Errors.Add(validationResult.ToString());
            return response;
        }

        try
        {
            await _animeService.InsertAsync((Core.Models.Anime)anime);
        }
        catch (Exception e)
        {
            response.Errors.Add(e.ToString());
        }

        return response;
    }
}
