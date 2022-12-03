using BC =  BCrypt.Net;
namespace SilevisHackathon.Domain.Models;

public class Person
{
    private Person() {}

    public Person(string nickName, string fistName, string lastName)
    {
        NickName = nickName;
        FirstName = fistName;
        LastName = lastName;
    }
    
    public int Id { get; set; }
    public string NickName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public int? TeamId { get; set; }
    public Team? Team { get; set; }
    public ICollection<Message> Messages { get; set; } = new List<Message>();

}

