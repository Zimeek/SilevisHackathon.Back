namespace SilevisHackathon.Domain.Models;

public class Location
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public Event Event { get; set; }
}