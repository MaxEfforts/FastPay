
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace FastPayDB.Repositories.Interfaces;

public interface IRepository<TEntity> where TEntity : class
{
    public Task<List<TEntity?>> GetAllAsync();

    public Task<TEntity?> GetAsync(Expression<Func<TEntity?, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        string includeProperties = null);

    public Task<IEnumerable<TEntity?>> GetAllAsync(Expression<Func<TEntity?, bool>> filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null);

    public  Task<EntityEntry<TEntity?>> Add(TEntity entity);

    public Task Add(IEnumerable<TEntity> entities);

    public Task Remove(int id);

    public void Remove(TEntity? entity);
    
    public Task Update(int id);

    public void Update(TEntity? entity);

    public void RemoveRange(IEnumerable<TEntity> entity);

    public IQueryable<TEntity?> Table();

    
}

