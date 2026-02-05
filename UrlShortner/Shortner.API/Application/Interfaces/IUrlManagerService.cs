using Shortner.API.Application.Contracts.Requests;

namespace Shortner.API.Application.Interfaces
{
    public interface IUrlManagerService
    {
        string UrlToHash(CreateURLRequest urlRequest);
        string CompressUrlWithZstd(CreateURLRequest urlRequest);
    }
}