using IntroAspNet.Domain.Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IntroAspNet.DataProvider.Mappings
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(x => x.IsDeleted).HasDefaultValue(0);
            builder.Property(x => x.UpdatedBy).IsRequired(false);
            builder.Property(x => x.DeletedBy).IsRequired(false);

            builder.HasData(new()
            {
                Id = Guid.Parse("BCFFFAE0-0887-418A-9EC6-88D103B61DFE"),
                Name = "Category 1",
                CreatedBy = "sa"
            }, new()
            {
                Id = Guid.Parse("5040350E-2655-4B91-9A39-233ECF87E0C4"),
                Name = "Category 2",
                CreatedBy = "sa"
            });
        }
    }
}
