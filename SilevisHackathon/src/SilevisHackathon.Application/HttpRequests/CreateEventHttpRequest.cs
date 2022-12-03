using System.ComponentModel.DataAnnotations;

namespace SilevisHackathon.Application.HttpRequests;

public record CreateEventHttpRequest
{
    [Required]
    public string Name { get; init; }
    [Required]
    public int LocationId { get; init; }
    [Required]
    [DataType(DataType.DateTime)]
    public DateTime Date { get; init; }
    [Required]
    public string Time { get; init; }
}