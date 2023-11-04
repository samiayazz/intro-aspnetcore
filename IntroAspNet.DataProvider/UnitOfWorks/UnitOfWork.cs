using IntroAspNet.DataProvider.Context;
using IntroAspNet.DataProvider.Repositories.Abstraction;
using IntroAspNet.DataProvider.Repositories.Concretes;

namespace IntroAspNet.DataProvider.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;
        public UnitOfWork(AppDbContext dbContext) => _dbContext = dbContext;

        public async ValueTask DisposeAsync() => await _dbContext.DisposeAsync();
        public int Save() => _dbContext.SaveChanges();
        public async Task<int> SaveAsync() => await _dbContext.SaveChangesAsync();
        IRepository<TEntity> IUnitOfWork.GetRepository<TEntity>() => new Repository<TEntity>(_dbContext);
    }
}
