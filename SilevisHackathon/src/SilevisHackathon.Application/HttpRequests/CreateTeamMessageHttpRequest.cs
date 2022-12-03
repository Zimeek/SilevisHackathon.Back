using System.ComponentModel.DataAnnotations;

namespace SilevisHackathon.Application.HttpRequests;

public record CreateTeamMessageHttpRequest
{
    [Required]
    public int TeamId { get; set; }
    [Required]
    public string Content { get; set; }
}