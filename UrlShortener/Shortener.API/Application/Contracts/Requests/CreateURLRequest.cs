using System.ComponentModel.DataAnnotations;

namespace UrlShortener.API.Application.Contracts.Requests
{
    public class CreateURLRequest
    {
        [Required]
        public string Url { get; set; }
    }
}