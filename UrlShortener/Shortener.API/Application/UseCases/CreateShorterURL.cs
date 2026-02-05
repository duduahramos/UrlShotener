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
            var shortenUrl = _urlManagerService.UrlToHash(urlRequest);
            var expirationInMinutes = 5;

            var saveResult = await _cacheService.SaveAsync(shortenUrl, urlRequest.OriginalUrl, expirationInMinutes);
            
            return new UrlResponse()
            {
                OriginalUrl = urlRequest.OriginalUrl,
                ShortCode = shortenUrl,
                ExpiresAt = DateTime.UtcNow.AddMinutes(expirationInMinutes).ToString("dd/MM/yyyy HH:mm:ss")
            };
        }

        public async Task<UrlResponse>  CompressUrlZstdAndSaveAsync(CreateURLRequest urlRequest)
        {
            var shortenUrl = _urlManagerService.CompressUrlWithZstd(urlRequest);
            
            return new UrlResponse()
            {
                OriginalUrl = urlRequest.OriginalUrl,
                ShortCode = shortenUrl,
                ExpiresAt = ""
            };
        }
    }
}
