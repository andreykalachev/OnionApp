using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OnionApp.Domain.Models.DTO;

namespace OnionApp.Domain.Interfaces.Services
{
    public interface ICountryService
    {
        Task<IEnumerable<CountryBasicInfoDto>> GetAllEnabledBasicInfoAsync();

        Task<string> GetPostalCodeFormatAsync(Guid id);

        Task<string> GetPostalCodeFormatByCountryNameAsync(string countryName);
    }
}
