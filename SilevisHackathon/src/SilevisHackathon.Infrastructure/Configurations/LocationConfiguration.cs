using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SilevisHackathon.Domain.Models;

namespace SilevisHackathon.Infrastructure.Configurations;

public class LocationConfiguration : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.HasKey(location => location.Id);
        builder.ToTable("Locations");

        builder
            .HasOne(l => l.Event)
            .WithOne(e => e.Location)
            .HasForeignKey<Event>(e => e.LocationId);
    }
}