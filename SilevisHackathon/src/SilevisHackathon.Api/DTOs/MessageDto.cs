namespace SilevisHackathon.Api.DTOs;

public record MessageDto
{
    public int Id { get; init; }
    public string Content { get; init; }
    public int AuthorId { get; init; }
}