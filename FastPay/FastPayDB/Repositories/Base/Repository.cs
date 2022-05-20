
using System.Linq.Expressions;
using FastPayDB.Context;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace FastPayDB.Repositories.Base;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    protected readonly ApplicationDbContext _context;
    private DbSet<TEntity?> _dbSet;

    #region Constractor

    public Repository(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _dbSet = context.Set<TEntity>();
    }

    #endregion

    #region GetAllAsync

    public async Task<List<TEntity?>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }
    
    #endregion
    
    #region Get
    public async Task<TEntity?> GetAsync(Expression<Func<TEntity?, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null)
    {
        IQueryable<TEntity?> query = _dbSet;

        if(filter != null)
        {
            query = query.Where(filter);
        }

        if(includeProperties != null)
        {
            foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProp);
            }
        }

        if (orderBy != null)
        {
            return await orderBy(query).FirstOrDefaultAsync();
        }
        return await query.FirstOrDefaultAsync();
    }
    
    #endregion
    
    #region GetAll

    public async Task<IEnumerable<TEntity?>> GetAllAsync(Expression<Func<TEntity?, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null)
    {
        IQueryable<TEntity?> query = _dbSet;

        if(filter != null)
        {
            query = query.Where(filter);
        }

        if(includeProperties != null)
        {
            foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProp);
            }
        }

        if (orderBy != null)
        {
            return await orderBy(query).ToListAsync();
        }
        return await query.ToListAsync();
    }


    #endregion

    #region Add Entity

    public async Task<EntityEntry<TEntity?>> Add(TEntity entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));
            
        return await this._dbSet.AddAsync(entity);
    }
    
    #endregion

    #region Add Entity Range

    public async Task Add(IEnumerable<TEntity> entities)
    {
        if (entities == null)
            throw new ArgumentNullException(nameof(entities));
            
        await this._dbSet.AddRangeAsync(entities);
    }

    #endregion

    #region Remove Entity by id

    public async Task Remove(int id)
    {
        TEntity? entity = await _dbSet.FindAsync(id);
        Remove(entity);
    }

    #endregion

    #region Remove

    public  void Remove(TEntity? entity)
    {
        _dbSet.Remove(entity);
    }
    
    #endregion
    
    #region Update Entity by id

    public async Task Update(int id)
    {
        TEntity? entity = await _dbSet.FindAsync(id);
        Update(entity);
    }

    #endregion

     #region Update

    public  void Update(TEntity? entity)
    {
        _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        //_dbSet.Update(entity);
    }
    
    #endregion

    
    #region RemoveRange

    public void RemoveRange(IEnumerable<TEntity> entity)
    {
        _dbSet.RemoveRange(entity);
    }

    #endregion
    
    #region Table

    /// <summary>
    /// Gets a table
    /// </summary>
    public IQueryable<TEntity?> Table()
    {
        IQueryable<TEntity?> query = _dbSet;
        return query;
    } 
        
    #endregion
    
}
