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

        public async Task<UrlResponse> HashUrlAndSaveAsync(CreateURLRequest urlRequest)
        {
            var hashedUrl = _urlManagerService.UrlToHash(urlRequest);

            var saveResult = await _cacheService.SaveAsync(hashedUrl, urlRequest.Url, 1);
            
            return new UrlResponse()
            {
                Url = hashedUrl
            };
        }

        public async Task<UrlResponse>  CompressUrlZstdAndSaveAsync(CreateURLRequest urlRequest)
        {
            var compressedURL = _urlManagerService.CompressUrlWithZstd(urlRequest);
            
            return new UrlResponse()
            {
                Url = compressedURL
            };
        }
    }
}
