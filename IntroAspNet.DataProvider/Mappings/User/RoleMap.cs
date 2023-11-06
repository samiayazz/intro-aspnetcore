using IntroAspNet.Domain.Entities.Concretes.AppUser;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IntroAspNet.DataProvider.Mappings.User
{
    public class RoleMap : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            // Primary key
            builder.HasKey(r => r.Id);

            // Index for "normalized" role name to allow efficient lookups
            builder.HasIndex(r => r.NormalizedName).HasName("RoleNameIndex").IsUnique();

            // Maps to the AspNetRoles table
            builder.ToTable("AspNetRoles");

            // A concurrency token for use with the optimistic concurrency checking
            builder.Property(r => r.ConcurrencyStamp).IsConcurrencyToken();

            // Limit the size of columns to use efficient database types
            builder.Property(u => u.Name).HasMaxLength(256);
            builder.Property(u => u.NormalizedName).HasMaxLength(256);

            // The relationships between Role and other entity types
            // Note that these relationships are configured with no navigation properties

            // Each Role can have many entries in the UserRole join table
            builder.HasMany<AppUserRole>().WithOne().HasForeignKey(ur => ur.RoleId).IsRequired();

            // Each Role can have many associated RoleClaims
            builder.HasMany<AppRoleClaim>().WithOne().HasForeignKey(rc => rc.RoleId).IsRequired();

            builder.HasData(new AppRole
            {
                Id = Guid.Parse("F73B57E4-C2B5-4A85-8EDB-F12BE6D2E740"),
                Name = "superadmin",
                NormalizedName = "Super Admin",
                ConcurrencyStamp = Guid.NewGuid().ToString()
            }, new AppRole
            {
                Id = Guid.Parse("985DA856-3EA2-4780-A7E4-70DDD53B1C3D"),
                Name = "admin",
                NormalizedName = "Admin",
                ConcurrencyStamp = Guid.NewGuid().ToString()
            }, new AppRole
            {
                Id = Guid.Parse("D54C4496-DB72-4C3B-8663-A54C6BA49C5F"),
                Name = "user",
                NormalizedName = "User",
                ConcurrencyStamp = Guid.NewGuid().ToString()
            });
        }
    }
}
