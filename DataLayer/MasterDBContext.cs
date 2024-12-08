using DataLayer.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace DataLayer;

public class MasterDBContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
{

    public MasterDBContext(DbContextOptions<MasterDBContext> options) : base(options)
    {
        
    }
    public DbSet<Area> Areas { get; set; }
    public DbSet<Job> Jobs { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MasterDBContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
