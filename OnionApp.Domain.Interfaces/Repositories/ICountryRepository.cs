using System.Threading.Tasks;
using OnionApp.Domain.Models.Entities;

namespace OnionApp.Domain.Interfaces.Repositories
{
    public interface ICountryRepository : IGenericRepository<Country>
    {
        Task<string> GetPostCodeFormatByCountryName(string countryName);
    }
}
