using System.ComponentModel.DataAnnotations;

namespace Shortner.API.Application.Contracts.Requests
{
    public class CreateURLRequest
    {
        [Required]
        public required string OriginalUrl { get; set; }
    }
}