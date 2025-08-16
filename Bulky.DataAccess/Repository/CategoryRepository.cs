using System.Linq.Expressions;
using Bulky.Models.Entities;

namespace Bulky.DataAccess.Repository;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    public CategoryRepository(AppDbContext appDbContext) : base(appDbContext) { }

    public void Update(Category entity)
    {
        AppDbContext.Update(entity);
    }

    public async Task SaveAsync()
    {
        await AppDbContext.SaveChangesAsync();
    }
}