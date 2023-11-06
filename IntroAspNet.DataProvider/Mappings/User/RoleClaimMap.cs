using IntroAspNet.Domain.Entities.Concretes.AppUser;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IntroAspNet.DataProvider.Mappings.User
{
    public class RoleClaimMap : IEntityTypeConfiguration<AppRoleClaim>
    {
        public void Configure(EntityTypeBuilder<AppRoleClaim> builder)
        {
            // Primary key
            builder.HasKey(rc => rc.Id);

            // Maps to the AspNetRoleClaims table
            builder.ToTable("AspNetRoleClaims");
        }
    }
}
