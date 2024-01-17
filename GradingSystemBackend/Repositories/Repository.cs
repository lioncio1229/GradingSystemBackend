using GradingSystemBackend.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GradingSystemBackend.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        internal DataContext _context;
        internal DbSet<TEntity> _dbSet;

        public Repository(DataContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public Task<TEntity> Get(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = Include<TEntity>(includes);
            return query.Where(predicate).FirstOrDefaultAsync<TEntity>();
        }

        public IQueryable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includes)
        {
            var query = Include<TEntity>(includes);
            return query.AsQueryable();
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbSet.AsQueryable();
        }

        public Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var query = Include<TEntity>();
            return query.Where(predicate).ToListAsync();
        }

        public IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> expression)
        {
            return _dbSet.Where(expression);
        }

        public IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> expression, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = Include<TEntity>(includes);
            return query.Where(expression);
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            _dbSet.Update(entity);
            return await Task.FromResult<TEntity>(entity);
        }

        private IQueryable<T> Include<T>(params Expression<Func<T, object>>[] paths) where T : class
        {
            try
            {
                IQueryable<T> query = _context.Set<T>();
                return paths.Aggregate(query, (current, path) => current.Include(path));
            }
            catch
            {
                throw;
            }
        }
    }
}
