namespace IntroAspNet.Domain.Entities.Abstraction
{
    public interface IEntity
    {
        Guid Id { get; set; }

        string CreatedBy { get; set; }
        DateTime CreatedAt { get; set; }

        string UpdatedBy { get; set; }
        DateTime? UpdatedAt { get; set; }

        bool IsDeleted { get; set; }
        string DeletedBy { get; set; }
        DateTime? DeletedAt { get; set; }
    }
}
