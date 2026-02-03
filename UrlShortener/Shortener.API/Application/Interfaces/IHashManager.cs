namespace UrlShortener.API.Application.Interfaces
{
    public interface IHashManager
    {
        string? XxHash(string input);
    }
}