using Microsoft.AspNetCore.Mvc;

namespace Eri.Api.Controllers;

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