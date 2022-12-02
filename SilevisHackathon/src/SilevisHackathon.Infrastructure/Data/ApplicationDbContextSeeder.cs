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
                new Location("FIFA World Cup Qatar 2022 1", "Al Bayt Stadium"),
                new Location("FIFA World Cup Qatar 2022 2", "Ahmad Bin Ali Stadium"),
                new Location("FIFA World Cup Qatar 2022 3", "Al Janoub Stadium")
            };

            await dbContext.Locations.AddRangeAsync(locations);
        }

        await dbContext.SaveChangesAsync();
    }
}