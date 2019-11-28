using System.Collections.Generic;
using System.Threading.Tasks;
using OnionApp.Domain.Core.Entities;
using OnionApp.Services.ServiceModels.DTOs;

namespace OnionApp.Services.Interfaces
{
    public interface IRelationService
    {
        Task<RelationBasicInfoDto> GetASync(int id);

        Task<IEnumerable<RelationBasicInfoDto>> GetBasicInfoAllAsync();

        Task<IEnumerable<RelationBasicInfoDto>> GetAllOfCategoryAsync(Category category);

        int Add(Relation relation);

        Task DeleteAsync(int id);

        Task DeleteRangeAsync(IEnumerable<int> relationToDeleteIds);

        Task UpdateAsync(RelationBasicInfoDto relationBasicInfoDto);
    }
}
