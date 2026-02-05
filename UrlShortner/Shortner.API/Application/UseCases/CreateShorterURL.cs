using System.Net;
using Shortner.API.Application.Contracts.Requests;
using Shortner.API.Application.Contracts.Response;
using Shortner.API.Application.Interfaces;

namespace Shortner.API.Application.UseCases
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
            var shortnUrl = _urlManagerService.UrlToHash(urlRequest);
            var expirationInMinutes = 5;

            var saveResult = await _cacheService.SaveAsync(shortnUrl, urlRequest.OriginalUrl, expirationInMinutes);
            
            return new UrlResponse()
            {
                OriginalUrl = urlRequest.OriginalUrl,
                ShortCode = shortnUrl,
                ExpiresAt = DateTime.UtcNow.AddMinutes(expirationInMinutes).ToString("dd/MM/yyyy HH:mm:ss")
            };
        }

        public async Task<UrlResponse>  CompressUrlZstdAndSaveAsync(CreateURLRequest urlRequest)
        {
            var shortnUrl = _urlManagerService.CompressUrlWithZstd(urlRequest);
            
            return new UrlResponse()
            {
                OriginalUrl = urlRequest.OriginalUrl,
                ShortCode = shortnUrl,
                ExpiresAt = ""
            };
        }
    }
}
