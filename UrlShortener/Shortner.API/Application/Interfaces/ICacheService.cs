namespace Shortener.API.Application.Interfaces
{
    public interface ICacheService
    {
        Task<bool> SaveAsync(string key, string value, int _urlExpirationInSeconds);
        Task<string> GetAsync(string key);
    }
}