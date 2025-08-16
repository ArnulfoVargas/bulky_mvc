namespace Bulky.DataAccess.Repository;

public interface IUnitOfWork
{
    public ICategoryRepository Category { get; }
    
    public Task Save();
}