using System.Reflection;
using Microsoft.EntityFrameworkCore;
using SilevisHackathon.Domain.Models;

namespace SilevisHackathon.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public DbSet<Location> Locations { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<Person> People { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<Message> Messages { get; set; }
}