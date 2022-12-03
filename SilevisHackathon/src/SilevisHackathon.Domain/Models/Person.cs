using System.Text.Json.Serialization;
using BC =  BCrypt.Net;
namespace SilevisHackathon.Domain.Models;

public class Person
{
    private Person() {}

    public Person(string fistName, string lastName, string password, string email)
    {
        FirstName = fistName;
        LastName = lastName;
        PasswordHash = BC.BCrypt.HashPassword(password);
        Email = email;
    }
    
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public int? TeamId { get; set; }
    [JsonIgnore]
    public Team? Team { get; set; }
    public ICollection<EventMessage> EventMessages { get; set; } = new List<EventMessage>();
    public ICollection<TeamMessage> TeamMessages { get; set; } = new List<TeamMessage>();

}

