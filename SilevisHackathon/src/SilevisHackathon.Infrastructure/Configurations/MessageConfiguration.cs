using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SilevisHackathon.Domain.Models;

namespace SilevisHackathon.Infrastructure.Configurations;

public class MessageConfiguration : IEntityTypeConfiguration<Message>
{
    public void Configure(EntityTypeBuilder<Message> builder)
    {
        builder.HasKey(m => m.Id);
        builder.ToTable("Messages");

        builder
            .HasOne(m => m.Person)
            .WithMany(p => p.Messages)
            .HasForeignKey(m => m.PersonId);

        builder
            .HasOne(m => m.Team)
            .WithMany(t => t.Messages)
            .HasForeignKey(m => m.TeamId);
        
        builder
            .HasOne(m => m.Event)
            .WithMany(e => e.Messages)
            .HasForeignKey(m => m.EventId);
    }
}