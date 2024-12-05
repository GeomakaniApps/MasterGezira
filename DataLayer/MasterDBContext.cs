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
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MasterDBContext).Assembly);
        base.OnModelCreating(modelBuilder);

        /*seed roles into database on startup use ApplicationRole not IdentityRole*/

        //modelBuilder.Entity<ApplicationRole>().HasData(
        //         new ApplicationRole
        //         {
        //             Id = 1,
        //             Name = RoleEnum.Admin,
        //             NormalizedName = RoleEnum.Admin.ToUpper()
        //         },
        //         new ApplicationRole
        //         {
        //             Id = 2,
        //             Name = RoleEnum.LockerAdmin,
        //             NormalizedName = RoleEnum.LockerAdmin.ToUpper()
        //         },
        //          new ApplicationRole
        //          {
        //              Id = 3,
        //              Name = RoleEnum.ActivityAdmin,
        //              NormalizedName = RoleEnum.ActivityAdmin.ToUpper()
        //          },
        //          new ApplicationRole
        //          {
        //               Id = 4,
        //               Name = RoleEnum.EventAdmin,
        //               NormalizedName = RoleEnum.EventAdmin.ToUpper()
        //          },
        //          new ApplicationRole
        //          {
        //               Id = 5,
        //               Name = RoleEnum.ResortAdmin,
        //               NormalizedName = RoleEnum.ResortAdmin.ToUpper()
        //          },
        //          new ApplicationRole
        //          {
        //               Id = 6,
        //               Name = RoleEnum.TripAdmin,
        //               NormalizedName = RoleEnum.TripAdmin.ToUpper()
        //          },
        //          new ApplicationRole
        //          {
        //               Id = 7,
        //               Name = RoleEnum.AreaAdmin,
        //               NormalizedName = RoleEnum.AreaAdmin.ToUpper()
        //          },
        //          new ApplicationRole
        //          {
        //              Id = 8,
        //              Name = RoleEnum.MembershipAdmin,
        //              NormalizedName = RoleEnum.MembershipAdmin.ToUpper()
        //          },
        //           new ApplicationRole
        //           {
        //               Id = 9,
        //               Name = RoleEnum.LockerEmployee,
        //               NormalizedName = RoleEnum.LockerEmployee.ToUpper()
        //           },
        //          new ApplicationRole
        //          {
        //              Id = 10,
        //              Name = RoleEnum.ActivityEmployee,
        //              NormalizedName = RoleEnum.ActivityEmployee.ToUpper()
        //          },
        //          new ApplicationRole
        //          {
        //              Id = 11,
        //              Name = RoleEnum.EventEmployee,
        //              NormalizedName = RoleEnum.EventEmployee.ToUpper()
        //          },
        //          new ApplicationRole
        //          {
        //              Id = 12,
        //              Name = RoleEnum.ResortEmployee,
        //              NormalizedName = RoleEnum.ResortEmployee.ToUpper()
        //          },
        //          new ApplicationRole
        //          {
        //              Id = 13,
        //              Name = RoleEnum.TripEmployee,
        //              NormalizedName = RoleEnum.TripEmployee.ToUpper()
        //          },
        //          new ApplicationRole
        //          {
        //              Id = 14,
        //              Name = RoleEnum.AreaEmployee,
        //              NormalizedName = RoleEnum.AreaEmployee.ToUpper()
        //          },
        //          new ApplicationRole
        //          {
        //              Id = 15,
        //              Name = RoleEnum.MembershipEmployee,
        //              NormalizedName = RoleEnum.MembershipEmployee.ToUpper()
        //          },
        //          new ApplicationRole
        //          {
        //              Id = 16,
        //              Name = RoleEnum.Payment,
        //              NormalizedName = RoleEnum.Payment.ToUpper()
        //          }
        //     );
    }
}
