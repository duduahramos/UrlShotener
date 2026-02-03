using System.Net;
using UrlShortener.API.Application.Contracts.Requests;
using UrlShortener.API.Application.Contracts.Response;
using UrlShortener.API.Application.Interfaces;

namespace UrlShortener.API.Application.UseCases
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
            var hashedURL = _urlManagerService.UrlToHash(urlRequest);

            var saveResult = await _cacheService.SaveAsync(urlRequest.Url, hashedURL, 1);
            
            return new UrlResponse()
            {
                Url = hashedURL,
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
