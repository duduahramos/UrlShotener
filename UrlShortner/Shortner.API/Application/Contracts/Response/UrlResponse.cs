using System.Net;
using System.Text.Json.Serialization;
namespace Shortner.API.Application.Contracts.Response
{
    public class UrlResponse
    {
        public required string OriginalUrl { get; set; }

        public required string ShortCode { get; set; }

        public required string ExpiresAt { get; set; }
        
    }
}
