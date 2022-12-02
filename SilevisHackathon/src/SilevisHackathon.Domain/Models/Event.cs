namespace SilevisHackathon.Domain.Models;

public class Event
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int LocationId { get; set; }
    public Location Location { get; set; }
    public ICollection<Team> Teams { get; set; }
    public DateTime Date { get; set; }
    public ICollection<Message> Messages { get; set; }

}