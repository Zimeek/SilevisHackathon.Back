namespace SilevisHackathon.Application.HttpRequests;

public record LoginHttpRequest
{
    public string Username { get; init; }
    public string Password { get; init; }
}