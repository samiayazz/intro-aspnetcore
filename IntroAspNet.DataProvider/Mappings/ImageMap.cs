using IntroAspNet.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IntroAspNet.DataProvider.Mappings
{
    public class ImageMap : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.Property(x => x.IsDeleted).HasDefaultValue(0);
            builder.Property(x => x.UpdatedBy).IsRequired(false);
            builder.Property(x => x.DeletedBy).IsRequired(false);

            builder.HasData(new()
            {
                Id = Guid.Parse("88FD2790-9DF1-49EC-832E-AF8CA7CA4349"),
                FileName = "Image 1",
                FileType = "png",
                CreatedBy = "sa"
            }, new()
            {
                Id = Guid.Parse("4A765BFA-780C-4C8F-AB94-22F66A2555AA"),
                FileName = "Image 2",
                FileType = "jpeg",
                CreatedBy = "sa"
            });
        }
    }
}
