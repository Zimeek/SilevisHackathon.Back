using System.ComponentModel.DataAnnotations;

namespace SilevisHackathon.Application.HttpRequests;

public record AddTeamToEventHttpRequest
{
    [Required]
    public int TeamId { get; init; }
    [Required]
    public int EventId { get; init; }
}