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
        private readonly GetShorterURL _getShorterURL;
        
        public ShortenerController(CreateShorterURL createShorterURL, GetShorterURL getShorterURL)
        {
            _createShorterURL = createShorterURL;
            _getShorterURL = getShorterURL;
        }

        [HttpPost]
        public async Task<IActionResult> CreateShorterUrlAsync([FromBody] CreateURLRequest request)
        {
            var shorterResponse = await _createShorterURL.HashUrlAndSaveAsync(request);

            return Ok(shorterResponse);
        }

        [HttpGet("/{urlKey}")]
        public async Task<IActionResult> GetShortedUrlAsync([FromRoute] string urlKey)
        {
            var shortedUrl = await _getShorterURL.GetShortedUrlAsync(urlKey);

            return Redirect(shortedUrl.Url);
        }
    }
}
