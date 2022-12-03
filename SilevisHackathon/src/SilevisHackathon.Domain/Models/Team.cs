namespace SilevisHackathon.Domain.Models;

public class Team
{
    private Team() {}

    public Team(string name, int captainId)
    {
        Name = name;
        CaptainId = captainId;
    }
    
    public int Id { get; set; }
    public string Name { get; set; }
    public int CaptainId { get; set; }
    public int? EventId { get; set; }
    public Event? Event { get; set; }
    public ICollection<TeamMessage> Messages { get; set; } = new List<TeamMessage>();
    public ICollection<Person> People { get; set; } = new List<Person>();

}