using System.Net;
using System.Text.Json.Serialization;

namespace UrlShortener.API.Application.Contracts.Response
{
    public class UrlResponse
    {
        public string? Url { get; set; }
        
        [JsonIgnore]
        public HttpStatusCode StatusCode { get; set; }
    }
}
