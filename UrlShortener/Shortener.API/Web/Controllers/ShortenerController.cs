using Microsoft.AspNetCore.Mvc;
using UrlShortener.API.Application.Contracts.Requests;
using UrlShortener.API.Application.UseCases;

namespace UrlShortener.API.Web.Controllers
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
