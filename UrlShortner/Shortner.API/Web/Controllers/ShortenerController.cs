using Microsoft.AspNetCore.Mvc;
using Shortner.API.Application.Contracts.Requests;
using Shortner.API.Application.UseCases;

namespace Shortner.API.Web.Controllers
{
    [ApiController]
    [Route("shortner")]
    public class ShortnerController : Controller
    {
        private readonly CreateShorterURL _createShorterURL;
        private readonly GetShorterURL _getShorterURL;
        
        public ShortnerController(CreateShorterURL createShorterURL, GetShorterURL getShorterURL)
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
            var urlResponse = await _getShorterURL.GetShortedUrlAsync(urlKey);

            return Ok(urlResponse);
        }
    }
}
