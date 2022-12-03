using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SilevisHackathon.Domain.Models;

namespace SilevisHackathon.Infrastructure.Configurations;

public class TeamMessageConfiguration : IEntityTypeConfiguration<TeamMessage>
{
    public void Configure(EntityTypeBuilder<TeamMessage> builder)
    {
        builder.HasKey(tm => tm.Id);
        builder.ToTable("TeamMessages");

        builder
            .HasOne(tm => tm.Team)
            .WithMany(t => t.Messages)
            .HasForeignKey(tm => tm.TeamId);
    }
}