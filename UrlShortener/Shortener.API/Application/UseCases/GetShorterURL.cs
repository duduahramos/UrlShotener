using System.Net;
using Shortener.API.Application.Contracts.Response;
using Shortener.API.Application.Interfaces;

namespace Shortener.API.Application.UseCases
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
            var shortedUrl = await _cacheService.GetAsync(urlKey);
            
            return new UrlResponse()
            {
                Url = shortedUrl
            };
        }
    }
}