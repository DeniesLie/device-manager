using System.Linq.Expressions;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
{
    protected readonly AppDbContext _dbContext;
    protected readonly DbSet<TEntity> _entities;

    public Repository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
        _entities = dbContext.Set<TEntity>();
    }

    public IQueryable<TEntity> Query(params Expression<Func<TEntity, object>>[] includes)
    {
        var dbSet = _dbContext.Set<TEntity>();
        var query = includes
            .Aggregate<Expression<Func<TEntity, object>>, IQueryable<TEntity>>
            (dbSet, (current, include) => current.Include(include));

        return query ?? dbSet;
    }


    public async Task<TEntity?> FindByIdAsync(params object[] keys)
        => await _entities.FindAsync(keys);

    public async Task<bool> Exists(params object[] keys)
        => await FindByIdAsync(keys) != null;
    
    public async Task<TEntity?> FindByCondition(Expression<Func<TEntity, bool>> predicate)
        => await _entities.FirstOrDefaultAsync(predicate);

    public void Add(TEntity entity)
        => _entities.Add(entity);

    public void AddRange(IEnumerable<TEntity> entities)
        => _entities.AddRange(entities);

    public void Remove(TEntity entity)
        => _entities.Remove(entity);

    public void RemoveRange(IEnumerable<TEntity> entities)
        => _entities.RemoveRange(entities);

    public void Update(TEntity entity)
        => _entities.Update(entity);

    public Task<int> SaveChangesAsync()
        => _dbContext.SaveChangesAsync();

}