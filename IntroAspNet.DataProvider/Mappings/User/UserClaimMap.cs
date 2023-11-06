using IntroAspNet.Domain.Entities.Concretes.AppUser;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IntroAspNet.DataProvider.Mappings.User
{
    public class UserClaimMap : IEntityTypeConfiguration<AppUserClaim>
    {
        public void Configure(EntityTypeBuilder<AppUserClaim> builder)
        {
            // Primary key
            builder.HasKey(uc => uc.Id);

            // Maps to the AspNetUserClaims table
            builder.ToTable("AspNetUserClaims");
        }
    }
}
