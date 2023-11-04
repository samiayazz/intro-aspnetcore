using IntroAspNet.Domain.Entities.Abstraction;

namespace IntroAspNet.Domain.Entities.Concretes
{
    public sealed class Image : EntityBase
    {
        public string FileName { get; set; }
        public string FileType { get; set; }

        public Article Article { get; set; }
    }
}
