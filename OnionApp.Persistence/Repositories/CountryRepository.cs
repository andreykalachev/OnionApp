using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public async Task<string> GetPostCodeFormatByCountryName(string countryName)
        {
            var country = await DbSet.FirstOrDefaultAsync(x => x.Name == countryName);
            return country?.PostalCodeFormat;
        }
    }
}
