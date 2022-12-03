namespace SilevisHackathon.Application.HttpRequests;

public record CreateEventMessageHttpRequest
{
    public int EventId { get; init; }
    public string Content { get; init; }
}