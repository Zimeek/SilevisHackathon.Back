using System.ComponentModel.DataAnnotations;

namespace SilevisHackathon.Application.HttpRequests;

public record CreateTeamHttpRequest
{
    [Required]
    public string Name { get; init; }
    [Required]
    public int CaptainId { get; init; }
}