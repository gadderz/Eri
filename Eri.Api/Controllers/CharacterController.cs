using Eri.Api.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Eri.Api.Controllers;

[ApiKey]
[ApiController]
[Route("[controller]/[action]")]
public class CharacterController : ControllerBase
{
    private readonly ILogger<CharacterController> _logger;

    public CharacterController(ILogger<CharacterController> logger)
    {
        _logger = logger;
    }

    [HttpPost]
    public async Task<IActionResult> InsertAsync()
    {

    }
}