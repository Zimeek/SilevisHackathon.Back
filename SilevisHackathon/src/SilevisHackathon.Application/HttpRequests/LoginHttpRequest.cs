using System.ComponentModel.DataAnnotations;

namespace SilevisHackathon.Application.HttpRequests;

public record LoginHttpRequest
{
    [Required]
    [EmailAddress]
    public string Email { get; init; }
    [Required]
    public string Password { get; init; }
}