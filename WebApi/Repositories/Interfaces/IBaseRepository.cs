using System.Linq.Expressions;

namespace WebApi.Repositories.Interfaces;

public interface IBaseRepository<TEntity> where TEntity : class
{
    Task<bool> AddEntityAsync(TEntity entity);
    Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IQueryable<TEntity>>? includeExpression = null);
    Task<TEntity> UpdateEntityAsync(Expression<Func<TEntity, bool>> predicate, TEntity updatedEntity);
    Task<bool> AlreadyExistsAsync(Expression<Func<TEntity, bool>> predicate);
    Task<int> SaveAsync();
}
