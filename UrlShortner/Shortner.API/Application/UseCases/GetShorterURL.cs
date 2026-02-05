using System.Net;
using Shortner.API.Application.Contracts.Response;
using Shortner.API.Application.Interfaces;

namespace Shortner.API.Application.UseCases
{
    public class GetShorterURL
    {
        private readonly ICacheService _cacheService;

        public GetShorterURL(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }

        public async Task<UrlResponse> GetShortedUrlAsync(string urlKey)
        {
            var originalUrl = await _cacheService.GetAsync(urlKey);
            
            return new UrlResponse()
            {
                OriginalUrl = originalUrl,
                ShortCode = urlKey,
                ExpiresAt = ""
            };
        }
    }
}