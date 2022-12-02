namespace SilevisHackathon.Domain.Models;

public class Message
{   
    public int Id { get; set; }
    public string Content { get; set; }
    public int PersonId { get; set; }
    public Person Person { get; set; }
    public int? TeamId { get; set; }
    public Team Team { get; set; }
    public Event Event { get; set; }
    public int? EventId { get; set; }
    public DateTime Date { get; set; }
}