using Microsoft.AspNetCore.Mvc;
using Shortener.API.Application.Contracts.Requests;
using Shortener.API.Application.UseCases;

namespace Shortener.API.Web.Controllers
{
    [ApiController]
    [Route("shortener")]
    public class ShortenerController : Controller
    {
        private readonly CreateShorterURL _createShorterURL;
        
        public ShortenerController(CreateShorterURL createShorterURL)
        {
            _createShorterURL = createShorterURL;
        }

        [HttpPost]
        public async Task<IActionResult> ShortenAsync([FromBody] CreateURLRequest request)
        {
            var shorterResponse = _createShorterURL.ShortenUrlAndSaveInCache(request);
            
            return Ok(shorterResponse);
        }
    }
}
