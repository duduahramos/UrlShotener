using System.Net;
using Shortener.API.Application.Contracts.Requests;
using Shortener.API.Application.Interfaces;
using Shortener.API.Web.Contracts.Response;

namespace Shortener.API.Application.UseCases
{
    public class CreateShorterURL
    {
        private readonly IUrlManagerService _urlManagerService;

        public CreateShorterURL(IUrlManagerService urlManagerService)
        {
            _urlManagerService = urlManagerService;
        }

        public UrlResponse ShortenUrl(CreateURLRequest urlRequest)
        {
            var hashedURL = _urlManagerService.UrlToHash(urlRequest);

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
