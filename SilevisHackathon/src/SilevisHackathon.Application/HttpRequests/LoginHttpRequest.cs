namespace SilevisHackathon.Application.HttpRequests;

public record LoginHttpRequest
{
    public string Email { get; init; }
    public string Password { get; init; }
}