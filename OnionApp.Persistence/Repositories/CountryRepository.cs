using OnionApp.Domain.Interfaces.Repositories;
using OnionApp.Domain.Models.Entities;
using OnionApp.Persistence.Context;

namespace OnionApp.Persistence.Repositories
{
    public class CountryRepository : GenericRepository<Country>, ICountryRepository
    {
        public CountryRepository(DataContext context) : base(context)
        {
        }
    }
}
