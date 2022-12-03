using System.ComponentModel.DataAnnotations;

namespace SilevisHackathon.Application.HttpRequests;

public record AddPersonToTeamHttpRequest
{
    [Required]
    public int PersonId { get; init; }
    [Required]
    public int TeamId { get; init; }
}