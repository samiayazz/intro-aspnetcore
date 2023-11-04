using IntroAspNet.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IntroAspNet.DataProvider.Mappings
{
    public class ArticleMap : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.Property(x => x.ViewCount).HasDefaultValue(0);

            builder.Property(x => x.IsDeleted).HasDefaultValue(0);
            builder.Property(x => x.UpdatedBy).IsRequired(false);
            builder.Property(x => x.DeletedBy).IsRequired(false);

            builder.HasData(new()
            {
                Id = Guid.NewGuid(),
                Title = "Article 1",
                Content = "Article 1 Content",
                CategoryId = Guid.Parse("BCFFFAE0-0887-418A-9EC6-88D103B61DFE"),
                ImageId = Guid.Parse("88FD2790-9DF1-49EC-832E-AF8CA7CA4349"),
                CreatedBy = "sa",
            }, new()
            {
                Id = Guid.NewGuid(),
                Title = "Article 2",
                Content = "Article 2 Content",
                CategoryId = Guid.Parse("5040350E-2655-4B91-9A39-233ECF87E0C4"),
                ImageId = Guid.Parse("4A765BFA-780C-4C8F-AB94-22F66A2555AA"),
                CreatedBy = "sa",
            });
        }
    }
}
