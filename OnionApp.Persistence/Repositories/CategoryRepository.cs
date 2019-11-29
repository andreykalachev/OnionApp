using OnionApp.Domain.Models.Entities;
using OnionApp.Persistence.Context;

namespace OnionApp.Persistence.Repositories
{
    public class CategoryRepository : GenericRepository<Category>
    {
        public CategoryRepository(DataContext context) : base(context)
        {
        }
    }
}
