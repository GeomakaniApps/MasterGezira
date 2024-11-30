using Microsoft.EntityFrameworkCore;

namespace DataLayer;

public class MasterDBContext(DbContextOptions<MasterDBContext> options) : DbContext(options)
{


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MasterDBContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
