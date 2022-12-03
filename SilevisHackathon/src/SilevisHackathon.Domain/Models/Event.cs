namespace SilevisHackathon.Domain.Models;

public class Event
{
    private Event() {}

    public Event(string name, int locationId, DateTime date)
    {
        Name = name;
        LocationId = locationId;
        Date = date;
    }
    
    public int Id { get; set; }
    public string Name { get; set; }
    public int LocationId { get; set; }
    public Location Location { get; set; }
    public List<Team> Teams { get; set; } = new List<Team>();
    public DateTime Date { get; set; } = DateTime.UtcNow;
    public ICollection<EventMessage> Messages { get; set; } = new List<EventMessage>();

}