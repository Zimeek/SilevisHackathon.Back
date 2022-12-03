using BC =  BCrypt.Net;
namespace SilevisHackathon.Domain.Models;

public class Person
{
    public int Id { get; set; }
    public string NickName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public int? TeamId { get; set; }
    public Team? Team { get; set; }
    public ICollection<Message> Messages { get; set; }

}

