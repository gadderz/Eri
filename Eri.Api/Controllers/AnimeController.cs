using Eri.Api.Web;
using Microsoft.AspNetCore.Mvc;

namespace Eri.Api.Controllers;

[Route("[controller]/[action]")]
public class AnimeController : ControllerBase
{
    private readonly Anime _animeWebService;

    public AnimeController(Anime animeWebService)
    {
        _animeWebService = animeWebService;
    }

    [HttpPost]
    public async Task<IActionResult> InsertAsync([FromBody]Web.Models.Anime anime)
    {
        var response = await _animeWebService.InsertAsync(anime);

        if (response.HasErrors)
            return BadRequest(response.ToStringErrors());

        return Ok();
    }
}
