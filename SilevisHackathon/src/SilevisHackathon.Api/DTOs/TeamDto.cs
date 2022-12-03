namespace SilevisHackathon.Api.DTOs;

public record TeamDto
{
    public int Id { get; init; }
    public string Name { get; init; }
    public int CaptainId { get; init; }
    public ICollection<PersonDto> People { get; init; }
}