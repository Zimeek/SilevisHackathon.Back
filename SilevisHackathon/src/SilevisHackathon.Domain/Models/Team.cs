namespace SilevisHackathon.Domain.Models;

public class Team
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CaptainId { get; set; }
    public ICollection<Message> Messages { get; set; }
    public ICollection<Person> People { get; set; }

}