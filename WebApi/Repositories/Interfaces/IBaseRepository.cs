using System.Linq.Expressions;

namespace WebApi.Repositories.Interfaces;

public interface IBaseRepository<TEntity> where TEntity : class
{
    Task<bool> AddEntityAsync(TEntity entity);
    Task<bool> AlreadyExistsAsync(Expression<Func<TEntity, bool>> predicate);
    Task<int> SaveAsync();
}
