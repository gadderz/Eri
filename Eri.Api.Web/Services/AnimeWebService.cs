using Eri.Api.Web.Models;
using Eri.Core.Services;

namespace Eri.Api.Web.Services;

public class AnimeWebService
{
    private readonly AnimeService _animeService;

    public AnimeWebService(AnimeService animeService)
    {
        _animeService = animeService;
    }

    public async void InsertAsync(CreateAnime anime)
    {
        await _animeService.InsertAsync(anime);
    }
}
