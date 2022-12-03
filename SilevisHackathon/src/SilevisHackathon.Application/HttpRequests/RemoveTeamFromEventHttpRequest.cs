using System.ComponentModel.DataAnnotations;

namespace SilevisHackathon.Application.HttpRequests;

public record RemoveTeamFromEventHttpRequest
{
    [Required]
    public int TeamId { get; set; }
    [Required]
    public int EventId { get; set; }
}