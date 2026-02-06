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
        private readonly int _urlExpirationInSeconds;

        public CreateShorterURL(IUrlManagerService urlManagerService, ICacheService cacheService, IConfiguration configuration)
        {
            _urlManagerService = urlManagerService;
            _cacheService = cacheService;
            _urlExpirationInSeconds = configuration.GetValue<int>("Redis:UrlExpirationInSeconds");
        }

        public async Task<UrlResponse> HashUrlAndSaveAsync(CreateURLRequest urlRequest)
        {
            var shorterUrl = _urlManagerService.UrlToHash(urlRequest);

            var saveResult = await _cacheService.SaveAsync(shorterUrl, urlRequest.OriginalUrl, _urlExpirationInSeconds);

            return new UrlResponse()
            {
                OriginalUrl = urlRequest.OriginalUrl,
                ShortCode = shorterUrl,
                ExpiresAt = DateTime.UtcNow.AddSeconds(_urlExpirationInSeconds).ToString("dd/MM/yyyy HH:mm:ss")
            };
        }

        public async Task<UrlResponse> CompressUrlZstdAndSaveAsync(CreateURLRequest urlRequest)
        {
            var shorterUrl = _urlManagerService.CompressUrlWithZstd(urlRequest);

            return new UrlResponse()
            {
                OriginalUrl = urlRequest.OriginalUrl,
                ShortCode = shorterUrl,
                ExpiresAt = ""
            };
        }
    }
}