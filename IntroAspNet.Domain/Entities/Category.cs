using IntroAspNet.Domain.Abstraction;

namespace IntroAspNet.Domain.Entities
{
    public sealed class Category : EntityBase
    {
        public string Name { get; set; }

        public ICollection<Article> Articles { get; set; }
    }
}
