namespace SilevisHackathon.Application.HttpRequests;

public record AddPersonToTeamHttpRequest
{
    public int PersonId { get; init; }
    public int TeamId { get; init; }
}