namespace SilevisHackathon.Domain.Models;

public class TeamMessage
{
    private TeamMessage() {}

    public TeamMessage(string content, int authorId, int teamId)
    {
        Content = content;
        AuthorId = authorId;
        TeamId = teamId;
    }
    
    public int Id { get; set; }
    public string Content { get; set; }
    public int AuthorId { get; set; }
    public Person Author { get; set; }
    public int TeamId { get; set; }
    public Team Team { get; set; }
}