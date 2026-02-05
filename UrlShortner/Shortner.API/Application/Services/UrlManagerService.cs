using Shortner.API.Application.Contracts.Requests;
using Shortner.API.Application.Interfaces;

namespace Shortner.API.Application.Services
{
    public class UrlManagerService : IUrlManagerService
    {
        private readonly IHashManager _hashManager;

        public UrlManagerService(IHashManager hashManager)
        {
            _hashManager = hashManager;
        }

        public string UrlToHash(CreateURLRequest urlRequest)
        {
            return _hashManager.XxHash(urlRequest.OriginalUrl);
        }
        
        public string CompressUrlWithZstd(CreateURLRequest urlRequest)
        {
            return string.Empty;
        }
    }
}