using OnionApp.Domain.Models.Entities;
using OnionApp.Persistence.Context;

namespace OnionApp.Persistence.Repositories
{
    public class CountryRepository : GenericRepository<Country>
    {
        public CountryRepository(DataContext context) : base(context)
        {
        }
    }
}
