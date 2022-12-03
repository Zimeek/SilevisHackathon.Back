namespace SilevisHackathon.Domain.Models;

public class Event
{
    private Event() {}

    public Event(string name, int locationId, DateTime date, string time)
    {
        Name = name;
        LocationId = locationId;
        Date = date.Add(TimeSpan.Parse(time));
    }
    
    public int Id { get; set; }
    public string Name { get; set; }
    public int LocationId { get; set; }
    public Location Location { get; set; }
    public List<Team> Teams { get; set; } = new List<Team>();
    public DateTime Date { get; set; }
    public ICollection<EventMessage> Messages { get; set; } = new List<EventMessage>();

}