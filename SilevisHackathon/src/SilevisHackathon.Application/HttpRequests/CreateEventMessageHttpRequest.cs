using System.ComponentModel.DataAnnotations;

namespace SilevisHackathon.Application.HttpRequests;

public record CreateEventMessageHttpRequest
{
    [Required]
    public int EventId { get; init; }
    [Required]
    public string Content { get; init; }
}