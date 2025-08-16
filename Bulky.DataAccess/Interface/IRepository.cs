using System.Linq.Expressions;

namespace Bulky.DataAccess.Repository;

public interface IRepository<T> where T : class
{
    Task<List<T>> GetAllAsync();
    Task<List<T>> Take(int count = 10);
    Task<T?> Get(Expression<Func<T, bool>> filter);
    void Add(T entity);
    void Delete(T entity);
    void DeleteRange(Expression<Func<T, bool>> filter);
}