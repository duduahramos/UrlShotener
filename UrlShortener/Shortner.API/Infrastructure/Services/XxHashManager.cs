using System.IO.Hashing;
using System.Text;
using Shortener.API.Application.Interfaces;

namespace Shortener.API.Infrastructure.Services
{
    public class XxHashManager : IHashManager
    {
        public string XxHash(string input)
        {
            var bytes = Encoding.UTF8.GetBytes(input);
            var hash = XxHash64.Hash(bytes);

            return Convert.ToHexString(hash);
        }
    }
}