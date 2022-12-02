namespace SilevisHackathon.Api.DTOs;

public record LocationDto
{
    public int Id { get; init; }
    public string Name { get; init; }
    public string Address { get; init; }
}