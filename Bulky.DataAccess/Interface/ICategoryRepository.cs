using Bulky.Models.Entities;

namespace Bulky.DataAccess.Repository;

public interface ICategoryRepository : IRepository<Category>
{
    void Update(Category entity);
    // Task SaveAsync();
}