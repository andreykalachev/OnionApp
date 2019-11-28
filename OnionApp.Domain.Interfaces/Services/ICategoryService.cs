using System.Collections.Generic;
using System.Threading.Tasks;
using OnionApp.Domain.Models.DTO;

namespace OnionApp.Domain.Interfaces.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryBasicInfoDto>> GetBasicInfoAllAsync();
    }
}
