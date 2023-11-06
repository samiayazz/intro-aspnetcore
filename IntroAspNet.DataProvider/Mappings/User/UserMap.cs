using IntroAspNet.Domain.Entities.Concretes.AppUser;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IntroAspNet.DataProvider.Mappings.User
{
    public class UserMap : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            // Primary key
            builder.HasKey(u => u.Id);

            // Indexes for "normalized" username and email, to allow efficient lookups
            builder.HasIndex(u => u.NormalizedUserName).HasName("UserNameIndex").IsUnique();
            builder.HasIndex(u => u.NormalizedEmail).HasName("EmailIndex");

            // Maps to the AspNetUsers table
            builder.ToTable("AspNetUsers");

            // A concurrency token for use with the optimistic concurrency checking
            builder.Property(u => u.ConcurrencyStamp).IsConcurrencyToken();

            // Limit the size of columns to use efficient database types
            builder.Property(u => u.UserName).HasMaxLength(25);
            builder.Property(u => u.NormalizedUserName).HasMaxLength(256);
            builder.Property(u => u.Email).HasMaxLength(256);
            builder.Property(u => u.NormalizedEmail).HasMaxLength(256);

            // The relationships between User and other entity types
            // Note that these relationships are configured with no navigation properties

            // Each User can have many UserClaims
            builder.HasMany<AppUserClaim>().WithOne().HasForeignKey(uc => uc.UserId).IsRequired();

            // Each User can have many UserLogins
            builder.HasMany<AppUserLogin>().WithOne().HasForeignKey(ul => ul.UserId).IsRequired();

            // Each User can have many UserTokens
            builder.HasMany<AppUserToken>().WithOne().HasForeignKey(ut => ut.UserId).IsRequired();

            // Each User can have many entries in the UserRole join table
            builder.HasMany<AppUserRole>().WithOne().HasForeignKey(ur => ur.UserId).IsRequired();

            List<AppUser> users = new()
            {
                new()
                {
                    Id = Guid.Parse("5175A01D-0798-4E23-91DA-3D375C565188"),
                    UserName = "samiayaz",
                    NormalizedUserName = "Sami Ayaz",
                    Email = "samiayaz@gmail.com",
                    NormalizedEmail = "Sami Ayaz @ Gmail",
                    PhoneNumber = "5539592102",
                    Name = "Sami",
                    Surname = "AYAZ",
                    PhoneNumberConfirmed = true,
                    EmailConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString()
                },
                new()
                {
                    Id = Guid.Parse("643EC9DD-3C9E-4778-BBC6-7AE19B3C6896"),
                    UserName = "sefaayaz",
                    NormalizedUserName = "Sefa Ayaz",
                    Email = "sefaayaz@gmail.com",
                    NormalizedEmail = "Sefa Ayaz @ Gmail",
                    PhoneNumber = "1234567890",
                    Name = "Sefa",
                    Surname = "AYAZ",
                    PhoneNumberConfirmed = true,
                    EmailConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString()
                },
                new()
                {
                    Id = Guid.Parse("C36F5AD6-3914-4C98-AEBB-6ABEDE07C656"),
                    UserName = "numanayaz",
                    NormalizedUserName = "Numan Ayaz",
                    Email = "numanayaz@gmail.com",
                    NormalizedEmail = "Numan Ayaz @ Gmail",
                    PhoneNumber = "1234567890",
                    Name = "Numan",
                    Surname = "AYAZ",
                    PhoneNumberConfirmed = true,
                    EmailConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString()
                }

            };

            // Create password hashes
            users.ForEach(user => user.PasswordHash = CreatePasswordHash(user, user.UserName));

            builder.HasData(users);
        }

        string CreatePasswordHash(AppUser user, string password) => new PasswordHasher<AppUser>().HashPassword(user, password);
    }
}
