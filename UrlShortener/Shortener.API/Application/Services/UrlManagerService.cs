using UrlShortener.API.Application.Contracts.Requests;
using UrlShortener.API.Application.Interfaces;

namespace UrlShortener.API.Application.Services
{
    public class UrlManagerService : IUrlManagerService
    {
        private readonly IHashManager _hashManager;

        public UrlManagerService(IHashManager hashManager)
        {
            _hashManager = hashManager;
        }

        public string? UrlToHash(CreateURLRequest urlRequest)
        {
            return _hashManager.XxHash(urlRequest.Url);
        }
        
        public string? CompressUrlWithZstd(CreateURLRequest urlRequest)
        {
            return string.Empty;
        }
    }
}