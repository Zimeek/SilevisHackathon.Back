namespace SilevisHackathon.Api.DTOs;

public record PersonDto
{
    public int Id { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public int TeamId { get; init; }
}