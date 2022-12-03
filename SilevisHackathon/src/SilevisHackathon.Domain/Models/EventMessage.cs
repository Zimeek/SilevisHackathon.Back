namespace SilevisHackathon.Domain.Models;

public class EventMessage
{
    private EventMessage() {}

    public EventMessage(string content, int authorId, int eventId)
    {
        Content = content;
        AuthorId = authorId;
        EventId = eventId;
    }
    
    public int Id { get; set; }
    public string Content { get; set; }
    public int AuthorId { get; set; }
    public Person Author { get; set; }
    public int EventId { get; set; }
    public Event Event { get; set; }
}