using Shortener.API.Application.Contracts.Requests;

namespace Shortener.API.Application.Interfaces
{
    public interface IUrlManagerService
    {
        string UrlToHash(CreateURLRequest urlRequest);
        string CompressUrlWithZstd(CreateURLRequest urlRequest);
    }
}