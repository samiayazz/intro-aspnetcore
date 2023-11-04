using IntroAspNet.Domain.Entities.Abstraction;

namespace IntroAspNet.Domain.Entities.Concretes
{
    public sealed class Category : EntityBase
    {
        public string Name { get; set; }

        public ICollection<Article> Articles { get; set; }
    }
}
