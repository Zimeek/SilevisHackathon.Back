using System.Text.Json.Serialization;

namespace SilevisHackathon.Domain.Models;

public class Location
{
    private Location() {}

    public Location(string name, string address)
    {
        Name = name;
        Address = address;
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    [JsonIgnore]
    public Event Event { get; set; }
}