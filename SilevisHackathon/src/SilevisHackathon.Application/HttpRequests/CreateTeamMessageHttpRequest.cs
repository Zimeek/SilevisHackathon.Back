namespace SilevisHackathon.Application.HttpRequests;

public record CreateTeamMessageHttpRequest
{
    public int TeamId { get; set; }
    public string Content { get; set; }
}