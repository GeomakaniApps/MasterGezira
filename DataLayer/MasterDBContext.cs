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
    public DbSet<City> Cities { get; set; }
    public DbSet<Section> Section { get; set; }
    public DbSet<Transformation> Transformations { get; set; }
    public DbSet<MemberType> MemberTypes { get; set; }
    public DbSet<Nationality> Nationalities { get; set; }
    public DbSet<Qualification> Qualifications { get; set; }
    public DbSet<Reference> References { get; set; }
    public DbSet<Member> Members { get; set; }
    public DbSet<ImegesMemberAndMemRef> ImegesMemberAndMemRefs { get; set; }
    public DbSet<MembersRef> MembersRefs { get; set; }

    public DbSet<LateFees> LateFees { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MasterDBContext).Assembly);
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<MembersRef>()
.HasOne(mr => mr.Member)
.WithMany()
.HasForeignKey(mr => mr.MemberCode)
.HasPrincipalKey(m => m.MemberCode)
.OnDelete(DeleteBehavior.Restrict);
    }
}
