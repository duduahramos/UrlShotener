using System.Net;
using System.Text.Json.Serialization;

namespace Shortener.API.Web.Contracts.Response
{
    public class UrlResponse
    {
        public string? Url { get; set; }
        
        [JsonIgnore]
        public HttpStatusCode StatusCode { get; set; }
    }
}
