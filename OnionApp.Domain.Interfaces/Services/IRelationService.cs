using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OnionApp.Domain.Models.DTO;
using OnionApp.Domain.Models.Entities;

namespace OnionApp.Domain.Interfaces.Services
{
    public interface IRelationService
    {
        Task<RelationBasicInfoDto> GetASync(Guid id);

        Task<IEnumerable<RelationBasicInfoDto>> GetAllEnabledBasicInfoAsync();

        Task<IEnumerable<RelationBasicInfoDto>> GetAllEnabledOfCategoryAsync(Guid categoryId);

        Task AddAsync(Relation relation);

        Task DeleteAsync(Guid id);

        Task DeleteRangeAsync(IEnumerable<Guid> relationToDeleteIds);

        Task UpdateAsync(RelationBasicInfoDto relationBasicInfoDto);
    }
}
