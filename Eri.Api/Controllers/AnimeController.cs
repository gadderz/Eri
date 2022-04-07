using Eri.Api.Web.Models;
using Eri.Api.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace Eri.Api.Controllers;

[Route("[controller]/[action]")]
public class AnimeController : ControllerBase
{
    private readonly AnimeWebService _animeWebService;

    public AnimeController(AnimeWebService animeWebService)
    {
        _animeWebService = animeWebService;
    }

    [HttpPost]
    public async Task<IActionResult> InsertAsync([FromBody]Anime anime)
    {
        var response = await _animeWebService.InsertAsync(anime);

        if (response.HasErrors)
            return BadRequest(response.ToStringErrors());

        return Ok();
    }
}
