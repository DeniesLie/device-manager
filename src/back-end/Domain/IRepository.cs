using System.Linq.Expressions;

namespace Domain;

public interface IRepository<TEntity> where TEntity : IEntity
{
    IQueryable<TEntity> GetAll();

    Task<TEntity> FindByIdAsync(params object[] keys);

    Task<TEntity> FindByCondition(Expression<Func<TEntity, bool>> predicate);

    void Add(TEntity entity);

    void AddRange(IEnumerable<TEntity> entities);

    void Remove(TEntity entity);

    void RemoveRange(IEnumerable<TEntity> entities);

    void Update(TEntity entity);

    Task Update(TEntity entity, IEnumerable<string> fieldMask);

    Task<int> SaveChangesAsync();
}