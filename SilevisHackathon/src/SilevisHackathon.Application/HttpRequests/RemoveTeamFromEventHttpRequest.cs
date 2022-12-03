namespace SilevisHackathon.Application.HttpRequests;

public record RemoveTeamFromEventHttpRequest
{
    public int TeamId { get; set; }
    public int EventId { get; set; }
}