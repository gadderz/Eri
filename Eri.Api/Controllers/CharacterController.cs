using Microsoft.AspNetCore.Mvc;

namespace Eri.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class CharacterController : ControllerBase
{

    public CharacterController()
    {
    }

    [HttpPost]
    public async Task<IActionResult> InsertAsync()
    {
        return BadRequest();
    }
}