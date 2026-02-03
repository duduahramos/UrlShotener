using System.IO.Hashing;
using System.Text;
using Shortener.API.Application.Contracts.Requests;
using Shortener.API.Application.Interfaces;

namespace Shortener.API.Application.Services
{
    public class UrlManagerServiceService : IUrlManagerService
    {
        public UrlManagerServiceService()
        {
        }

        public string? UrlToHash(CreateURLRequest urlRequest)
        {
            var bytes = Encoding.UTF8.GetBytes(urlRequest.Url);
            var hash = XxHash64.Hash(bytes);

            return Convert.ToHexString(hash);
        }
        
        public string? CompressUrlWithZstd(CreateURLRequest urlRequest)
        {
            return string.Empty;
        }
    }
}