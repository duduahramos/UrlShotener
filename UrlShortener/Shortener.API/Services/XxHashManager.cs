using System.IO.Hashing;
using System.Text;
using UrlShortener.API.Application.Interfaces;

namespace UrlShortener.API.Infra.Services
{
    public class XxHashManager : IHashManager
    {
        public string? XxHash(string input)
        {
            var bytes = Encoding.UTF8.GetBytes(input);
            var hash = XxHash64.Hash(bytes);

            return Convert.ToHexString(hash);
        }
    }
}