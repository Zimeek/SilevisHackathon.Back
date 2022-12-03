using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SilevisHackathon.Domain.Models;

namespace SilevisHackathon.Infrastructure.Configurations;

public class EventMessageConfiguration : IEntityTypeConfiguration<EventMessage>
{
    public void Configure(EntityTypeBuilder<EventMessage> builder)
    {
        builder.HasKey(em => em.Id);
        builder.ToTable("EventMessages");
        
        
        builder
            .HasOne(em => em.Event)
            .WithMany(t => t.Messages)
            .HasForeignKey(em => em.EventId);
    }
}