using System.ComponentModel.DataAnnotations;

namespace SilevisHackathon.Application.HttpRequests;

public record CreatePersonHttpRequest
{
    [Required]
    public string FirstName { get; init; }
    [Required]
    public string LastName { get; init; }
    [Required]
    public string Password { get; init; }
    [Required]
    [EmailAddress]
    public string Email { get; init; }
}