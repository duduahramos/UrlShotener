using System.Net;
using Shortener.API.Application.Contracts.Requests;
using Shortener.API.Application.Contracts.Response;
using Shortener.API.Application.Interfaces;

namespace Shortener.API.Application.UseCases
{
    public class CreateShorterURL
    {
        private readonly IUrlManagerService _urlManagerService;
        private readonly ICacheService _cacheService;

        public CreateShorterURL(IUrlManagerService urlManagerService, ICacheService cacheService)
        {
            _urlManagerService = urlManagerService;
            _cacheService = cacheService;
        }

        public async Task<UrlResponse> ShortenUrlAndSaveInCache(CreateURLRequest urlRequest)
        {
            var hashedUrl = _urlManagerService.UrlToHash(urlRequest);

            var saveResult = await _cacheService.SaveAsync(urlRequest.Url, hashedUrl, 1);
            
            return new UrlResponse()
            {
                Url = hashedUrl,
                StatusCode = HttpStatusCode.Created
            };
        }

        public UrlResponse ShortenUrlZstd(CreateURLRequest urlRequest)
        {
            var compressedURL = _urlManagerService.CompressUrlWithZstd(urlRequest);

            return new UrlResponse()
            {
                Url = compressedURL,
                StatusCode = HttpStatusCode.Created
            };
        }
    }
}
