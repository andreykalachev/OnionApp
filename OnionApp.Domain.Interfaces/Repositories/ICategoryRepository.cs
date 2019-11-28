using System.Collections.Generic;
using System.Threading.Tasks;
using OnionApp.Domain.Core.DTOs;

namespace OnionApp.Domain.Interfaces.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<IdAndNameDto>> GetBasicInfoAllAsync();
    }
}
