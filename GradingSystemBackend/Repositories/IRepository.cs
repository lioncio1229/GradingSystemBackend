﻿using System.Linq.Expressions;

namespace GradingSystemBackend.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includes);
        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> AddAsync(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void UpdateAsync(TEntity entity);
        void Delete(TEntity entity);
        void DeleteRange(IEnumerable<TEntity> entities);
        Task<TEntity> Get(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes);
        IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> expression);
        IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> expression, params Expression<Func<TEntity, object>>[] includes);
    }
}
