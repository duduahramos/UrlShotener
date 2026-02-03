using UrlShortener.API.Application.Contracts.Requests;

namespace UrlShortener.API.Application.Interfaces
{
    public interface IUrlManagerService
    {
        string? UrlToHash(CreateURLRequest urlRequest);
        string? CompressUrlWithZstd(CreateURLRequest urlRequest);
    }
}