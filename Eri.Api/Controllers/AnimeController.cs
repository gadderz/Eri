using Eri.Api.Filters;
using Eri.Api.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Eri.Api.Controllers;

[ApiKey]
[ApiController]
[Route("[controller]/[action]")]
public class AnimeController : ControllerBase
{
    private readonly ILogger<AnimeController> _logger;

    public AnimeController(ILogger<AnimeController> logger)
    {
        _logger = logger;
    }

    [HttpPost]
    public async Task<IActionResult> InsertAsync(CreateAnime anime)
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState);


    }
}
