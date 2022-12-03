namespace SilevisHackathon.Application.HttpRequests;

public record CreateTeamHttpRequest
{
    public string Name { get; init; }
    public int CaptainId { get; init; }
}