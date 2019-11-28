using System.Collections.Generic;
using System.Threading.Tasks;
using OnionApp.Services.ServiceModels.DTOs;

namespace OnionApp.Services.Interfaces
{
    public interface ICountryService
    {
        Task<IEnumerable<CountryBasicInfoDto>> GetBasicInfoAllAsync();

        Task<string> GetPostalCodeFormatAsync(int id);
    }
}
