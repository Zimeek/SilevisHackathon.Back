namespace SilevisHackathon.Domain.Models;

public class Message
{   
    public int Id { get; set; }
    public string Content { get; set; }
    public int PersonId { get; set; }
    public DateTime Date { get; set; }
}