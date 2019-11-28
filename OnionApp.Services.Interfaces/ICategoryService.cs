using System.Collections.Generic;
using System.Threading.Tasks;
using OnionApp.Services.ServiceModels.DTOs;

namespace OnionApp.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryBasicInfoDto>> GetBasicInfoAllAsync();
    }
}
