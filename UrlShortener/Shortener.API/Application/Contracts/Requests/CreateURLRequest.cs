using System.ComponentModel.DataAnnotations;

namespace Shortener.API.Application.Contracts.Requests
{
    public class CreateURLRequest
    {
        [Required]
        public string Url { get; set; }
    }
}