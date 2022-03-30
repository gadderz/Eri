using Eri.Api.Web.Models;
using Eri.Api.Web.Validators;
using Eri.Core.Services;

namespace Eri.Api.Web.Services;

public class AnimeWebService
{
    private readonly AnimeService _animeService;

    public AnimeWebService(AnimeService animeService)
    {
        _animeService = animeService;
    }

    public async Task<Response> InsertAsync(Anime anime)
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
            await _animeService.InsertAsync(anime);
        }
        catch (Exception e)
        {
            response.Errors.Add(e.ToString());
        }

        return response;
    }
}
