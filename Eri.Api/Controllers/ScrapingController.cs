using Eri.Api.Web;
using Microsoft.AspNetCore.Mvc;

namespace Eri.Api.Controllers
{
    [Route("[controller]/[action]")]
    public class ScrapingController : ControllerBase
    {

        private readonly Scraping _scrapingService;

        public ScrapingController(Scraping scrapingService)
        {
            _scrapingService = scrapingService;
        }

        [HttpGet]
        public async Task<IActionResult> Anime()
        {
            await _scrapingService.AnimeAsync();

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
