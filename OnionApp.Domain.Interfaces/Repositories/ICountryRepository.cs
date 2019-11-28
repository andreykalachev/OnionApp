using System.Collections.Generic;
using System.Threading.Tasks;
using OnionApp.Domain.Core.DTOs;

namespace OnionApp.Domain.Interfaces.Repositories
{
    public interface ICountryRepository
    {
        Task<IEnumerable<IdAndNameDto>> GetBasicInfoAllAsync();

        Task<string> GetPostalCodeFormatAsync(int id);
    }
}
