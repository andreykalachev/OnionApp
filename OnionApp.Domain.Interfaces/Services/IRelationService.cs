using System.Collections.Generic;
using System.Threading.Tasks;
using OnionApp.Domain.Models.DTO;
using OnionApp.Domain.Models.Entities;

namespace OnionApp.Domain.Interfaces.Services
{
    public interface IRelationService
    {
        Task<RelationBasicInfoDto> GetASync(int id);

        Task<IEnumerable<RelationBasicInfoDto>> GetBasicInfoAllAsync();

        Task<IEnumerable<RelationBasicInfoDto>> GetAllOfCategoryAsync(int categoryId);

        int Add(Relation relation);

        Task DeleteAsync(int id);

        Task DeleteRangeAsync(IEnumerable<int> relationToDeleteIds);

        Task UpdateAsync(RelationBasicInfoDto relationBasicInfoDto);
    }
}
