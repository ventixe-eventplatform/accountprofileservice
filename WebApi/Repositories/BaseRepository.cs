using System.Diagnostics;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Repositories.Interfaces;

namespace WebApi.Repositories;

public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
{
    protected readonly DataContext _context;
    protected readonly DbSet<TEntity> _table;

    protected BaseRepository(DataContext context)
    {
        _context = context;
        _table = _context.Set<TEntity>();
    }

    public virtual async Task<bool> AddEntityAsync(TEntity entity)
    {
        if (entity == null)
            return false;

        try
        {
            await _table.AddAsync(entity);
            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error adding entity: {ex.Message}");
            throw;
        }
    }

    public virtual async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IQueryable<TEntity>>? includeExpression = null)
    {
        if (predicate == null)
            return null;

        IQueryable<TEntity> query = _table;

        if (includeExpression != null)
            query = includeExpression(query);

        return await query.FirstOrDefaultAsync(predicate);
    }

    public virtual async Task<TEntity> UpdateEntityAsync(Expression<Func<TEntity, bool>> predicate, TEntity updatedEntity)
    {
        if (updatedEntity == null)
            throw new ArgumentNullException();

        try
        {
            var entityToUpdate = await _table.FirstOrDefaultAsync(predicate);
            if (entityToUpdate == null)
                return null;

            _context.Entry(entityToUpdate).CurrentValues.SetValues(updatedEntity);
            return entityToUpdate;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error updating entity: {ex.Message}");
            throw;
        }
    }

    public virtual async Task<bool> AlreadyExistsAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _table.AnyAsync(predicate);
    }

    public virtual async Task<int> SaveAsync()
    {
        try
        {
            return await _context.SaveChangesAsync();
        }
        catch(Exception ex)
        {
            Debug.WriteLine($"Error saving changes: {ex.Message}");
            throw;
        }
    }
}

