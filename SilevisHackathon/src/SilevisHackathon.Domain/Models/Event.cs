namespace SilevisHackathon.Domain.Models;

public class Event
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int LocationId { get; set; }
    public int Team1 { get; set; }
    public int Team2 { get; set; }
    public DateTime Date { get; set; }
    
}