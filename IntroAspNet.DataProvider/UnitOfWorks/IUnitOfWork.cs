using IntroAspNet.DataProvider.Repositories.Abstraction;
using IntroAspNet.Domain.Entities.Abstraction;

namespace IntroAspNet.DataProvider.UnitOfWorks
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IEntity, new();
        int Save();
        Task<int> SaveAsync();
    }
}
