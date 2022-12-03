namespace SilevisHackathon.Application.HttpRequests;

public record CreatePersonHttpRequest
{
    public string NickName { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string Password { get; init; }
    public string Email { get; init; }
}