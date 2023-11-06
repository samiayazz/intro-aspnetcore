using IntroAspNet.Domain.Entities.Concretes.AppUser;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IntroAspNet.DataProvider.Mappings.User
{
    public class UserRoleMap : IEntityTypeConfiguration<AppUserRole>
    {
        public void Configure(EntityTypeBuilder<AppUserRole> builder)
        {
            // Primary key
            builder.HasKey(r => new { r.UserId, r.RoleId });

            // Maps to the AspNetUserRoles table
            builder.ToTable("AspNetUserRoles");

            builder.HasData(
            new()
            {
                UserId = Guid.Parse("5175A01D-0798-4E23-91DA-3D375C565188"),
                RoleId = Guid.Parse("F73B57E4-C2B5-4A85-8EDB-F12BE6D2E740")
            },
            new()
            {
                UserId = Guid.Parse("643EC9DD-3C9E-4778-BBC6-7AE19B3C6896"),
                RoleId = Guid.Parse("985DA856-3EA2-4780-A7E4-70DDD53B1C3D")
            },
            new()
            {
                UserId = Guid.Parse("C36F5AD6-3914-4C98-AEBB-6ABEDE07C656"),
                RoleId = Guid.Parse("D54C4496-DB72-4C3B-8663-A54C6BA49C5F")
            });
        }
    }
}
