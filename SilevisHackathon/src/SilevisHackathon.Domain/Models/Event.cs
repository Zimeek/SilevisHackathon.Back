namespace SilevisHackathon.Domain.Models;

public class Event
{
    private Event() {}

    public Event(string name, int locationId)
    {
        Name = name;
        LocationId = locationId;
    }
    
    public int Id { get; set; }
    public string Name { get; set; }
    public int LocationId { get; set; }
    public Location Location { get; set; }
    public ICollection<Team> Teams { get; set; } = new List<Team>();
    public DateTime Date { get; set; }
    public ICollection<Message> Messages { get; set; } = new List<Message>();

}