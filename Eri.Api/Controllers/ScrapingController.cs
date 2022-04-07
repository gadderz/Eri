using Microsoft.AspNetCore.Mvc;

namespace Eri.Api.Controllers
{
    [Route("[controller]/[action]")]
    public class ScrapingController : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> Anime()
        {
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Character()
        {
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> IsRunning()
        {
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Stop()
        {
            return Ok();
        }
    }
}
