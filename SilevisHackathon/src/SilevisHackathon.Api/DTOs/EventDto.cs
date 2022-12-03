namespace SilevisHackathon.Api.DTOs;

public record EventDto
{
    public int Id { get; init; }
    public string Name { get; init; }
    public LocationDto Location { get; init; }
    
}