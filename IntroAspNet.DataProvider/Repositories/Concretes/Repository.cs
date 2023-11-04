using IntroAspNet.DataProvider.Context;
using IntroAspNet.DataProvider.Repositories.Abstraction;
using IntroAspNet.Domain.Entities.Abstraction;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;

namespace IntroAspNet.DataProvider.Repositories.Concretes
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity, new()
    {
        private DbSet<TEntity> Table { get => _dbContext.Set<TEntity>(); }

        private readonly AppDbContext _dbContext;
        public Repository(AppDbContext dbContext) => _dbContext = dbContext;

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = Table;

            if (predicate is not null)
                query = query.Where(predicate);

            if (includeProperties.Any())
                foreach (var item in includeProperties)
                    query = query.Include(item);

            return await query.ToListAsync();
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = Table;
            query = query.Where(predicate);

            if (includeProperties.Any())
                foreach (var item in includeProperties)
                    query = query.Include(item);

            return await query.SingleAsync();
        }

        public async Task<TEntity> GetByIdAsync(Guid id, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            if (includeProperties.Any())
                foreach (var item in includeProperties)
                    Table.Include(item);

            return await Table.FindAsync(id);
        }

        public async Task AddAsync(TEntity entity)
            => await Table.AddAsync(entity);

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            await Task.Run(() => Table.Update(entity));
            return entity;
        }

        public async Task DeleteAsync(TEntity entity)
            => await Task.Run(() => Table.Remove(entity));

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
            => await Table.AnyAsync(predicate);

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate = null)
            => await Table.CountAsync(predicate);
    }
}
