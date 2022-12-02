namespace SilevisHackathon.Application.HttpRequests;

public record CreateEventHttpRequest
{
    public string Name { get; init; }
    public int LocationId { get; init; }
}