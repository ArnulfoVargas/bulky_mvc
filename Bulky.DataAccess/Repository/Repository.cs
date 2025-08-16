using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Bulky.DataAccess.Repository;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly AppDbContext AppDbContext;
    protected readonly DbSet<T>  DbSet;
    
    public Repository(AppDbContext appDbContext)
    {
        this.AppDbContext = appDbContext;
        DbSet  = this.AppDbContext.Set<T>();
    }
    
    public async Task<List<T>> GetAllAsync()
    {
        return await DbSet.ToListAsync();
    }

    public async Task<List<T>> Take(int count)
    {
        return await DbSet.Take(count).Order().ToListAsync(); 
    }

    public async Task<T?> Get(Expression<Func<T, bool>> filter)
    {
        return await DbSet.FirstOrDefaultAsync(filter);
    }

    public void Add(T entity)
    {
        DbSet.Add(entity);
    }

    public void Delete(T entity)
    {
        DbSet.Remove(entity);
    }

    public void DeleteRange(Expression<Func<T, bool>> filter)
    {
        DbSet.RemoveRange(DbSet.Where(filter));
    }
}