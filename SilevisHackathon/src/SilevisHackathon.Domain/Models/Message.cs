namespace SilevisHackathon.Domain.Models;

public class Message
{   
    public int Id { get; set; }
    public string Content { get; set; }
    public int PersonId { get; set; }
    public int? TeamId { get; set; }
    public int? EventId { get; set; }
    public DateTime Date { get; set; }
}