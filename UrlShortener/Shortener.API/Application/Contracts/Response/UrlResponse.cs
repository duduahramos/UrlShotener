using System.Net;
using System.Text.Json.Serialization;
namespace Shortener.API.Application.Contracts.Response
{
    public class UrlResponse
    {
        public required string Url { get; set; }
        
        [JsonIgnore]
        public required HttpStatusCode StatusCode { get; set; }
    }
}
