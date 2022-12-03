using Microsoft.EntityFrameworkCore;
using SilevisHackathon.Domain.Models;

namespace SilevisHackathon.Infrastructure.Data;

public static class ApplicationDbContextSeeder
{
    public static async Task SeedAsync(ApplicationDbContext dbContext)
    {
        if (dbContext.Database.IsSqlServer())
        {
            await dbContext.Database.MigrateAsync();
        }

        if (!dbContext.Locations.Any())
        {
            var locations = new List<Location>
            {
                new Location("Żytnia Hala", "Kielce"),
                new Location("KSM Szkoła", "Kielce"),
                new Location("Zagórska Pole", "Kielce"),
                new Location("Śródmieście Boisko", "Kielce")
            };

            await dbContext.Locations.AddRangeAsync(locations);
        }

        await dbContext.SaveChangesAsync();
    }
}