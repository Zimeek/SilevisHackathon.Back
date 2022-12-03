namespace SilevisHackathon.Application.HttpRequests;

public record AddTeamToEventHttpRequest
{
    public int TeamId { get; init; }
    public int EventId { get; init; }
}