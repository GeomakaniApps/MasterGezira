using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataLayer.Services;

public class LookupUpdater(MasterDBContext _context)
{
    public async Task SeedLookupDataAsync()
    {
        await SeedDataAsync<ApplicationRole>(
            new List<ApplicationRole>
            {
                 new ApplicationRole { Id = 1, Name = "Admin", NormalizedName = "Admin".ToUpper() },
                 new ApplicationRole { Id = 2, Name = "LockerAdmin", NormalizedName = "LockerAdmin".ToUpper() },
                 new ApplicationRole { Id = 3, Name = "ActivityAdmin", NormalizedName = "ActivityAdmin".ToUpper() },
                 new ApplicationRole { Id = 4, Name = "EventAdmin", NormalizedName = "EventAdmin".ToUpper() },
                 new ApplicationRole { Id = 5, Name = "TripAdmin", NormalizedName = "TripAdmin".ToUpper() },
                 new ApplicationRole { Id = 6, Name = "AreaAdmin", NormalizedName = "AreaAdmin".ToUpper() },
                 new ApplicationRole { Id = 7, Name = "MembershipAdmin", NormalizedName = "MembershipAdmin".ToUpper() },
                 new ApplicationRole { Id = 8, Name = "ResortAdmin", NormalizedName = "ResortAdmin".ToUpper() },
                 new ApplicationRole { Id = 9, Name = "LockerEmployee", NormalizedName = "LockerEmployee".ToUpper() },
                 new ApplicationRole { Id = 10, Name = "ActivityEmployee", NormalizedName = "ActivityEmployee".ToUpper() },
                 new ApplicationRole { Id = 11, Name = "EventEmployee", NormalizedName = "EventEmployee".ToUpper() },
                 new ApplicationRole { Id = 12, Name = "TripEmployee", NormalizedName = "TripEmployee".ToUpper() },
                 new ApplicationRole { Id = 13, Name = "AreaEmployee", NormalizedName = "AreaEmployee".ToUpper() },
                 new ApplicationRole { Id = 14, Name = "MembershipEmployee", NormalizedName = "MembershipEmployee".ToUpper() },
                 new ApplicationRole { Id = 15, Name = "ResortEmployee", NormalizedName = "ResortEmployee".ToUpper() },
                 new ApplicationRole { Id = 16, Name = "Payment", NormalizedName = "Payment".ToUpper() }
            },
            e => e.Id,
            e => e.Name,
            e => e.NormalizedName
           );
    }
    private async Task SeedDataAsync<T>(
    IEnumerable<T> entities,
    Expression<Func<T, object>> keySelector,
    Expression<Func<T, string>> nameSelector,
    Expression<Func<T, string>> displayNameSelectors) where T : class
    {
        var entityList = entities.ToList();

        // Retrieve all existing entities from the database
        var existingEntities = await _context.Set<T>().ToListAsync();

        // Compile the selectors once
        var compiledKeySelector = keySelector.Compile();
        var compiledNameSelector = nameSelector.Compile();
        var compiledDisplayNameSelector = displayNameSelectors.Compile();

        // Track keys of incoming entities for deletion check
        var incomingKeys = new HashSet<object>(entityList.Select(compiledKeySelector));

        // Loop through existing entities for deletion
        foreach (var existingEntity in existingEntities)
        {
            var key = compiledKeySelector(existingEntity);
            if (!incomingKeys.Contains(key))
            {
                _context.Set<T>().Remove(existingEntity);
            }
        }

        // Process incoming entities for addition and updates
        foreach (var entity in entityList)
        {
            var key = compiledKeySelector(entity);
            var existingEntity = await _context.Set<T>().FindAsync(key);

            if (existingEntity is null)
            {
                // Add new entity if it doesn't exist
                await _context.Set<T>().AddAsync(entity);
            }
            else
            {
                // Check if the name has changed
                var existingName = compiledNameSelector(existingEntity);
                if (existingName != compiledNameSelector(entity))
                {
                    // Update if the name is different
                    _context.Entry(existingEntity).CurrentValues.SetValues(entity);
                }
                // Check if the display name has changed
                var existingDisplayName = compiledDisplayNameSelector(existingEntity);
                if (existingDisplayName != compiledDisplayNameSelector(entity))
                {
                    // Update if the display name is different
                    _context.Entry(existingEntity).CurrentValues.SetValues(entity);
                }
            }
        }

        await _context.SaveChangesAsync(); // Commit changes
    }
}
