namespace IntroAspNet.Domain.Entities.Abstraction
{
    public abstract class EntityBase : IEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public bool IsDeleted { get; set; } = false;
        public string DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
