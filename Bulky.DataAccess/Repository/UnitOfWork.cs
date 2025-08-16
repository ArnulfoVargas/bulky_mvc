namespace Bulky.DataAccess.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    public ICategoryRepository Category { get; private set; }

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
        
        Category = new CategoryRepository(_context);
    }
    
    public async Task Save()
    {
        await _context.SaveChangesAsync();
    }
}