using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OnionApp.Domain.Models.DTO;
using OnionApp.Domain.Models.Entities;

namespace OnionApp.Domain.Interfaces.Services
{
    public interface IRelationService
    {
        Task<RelationBasicInfoDto> GetByIdAsync(Guid id);

        Task<IEnumerable<RelationBasicInfoDto>> GetAllEnabledBasicInfoAsync();

        Task<IEnumerable<RelationBasicInfoDto>> GetAllEnabledByCategoryIdAsync(Guid categoryId);

        Task CreateAsync(Relation relation);

        Task DisableAsync(Guid id);

        Task DisableRangeAsync(IEnumerable<Guid> relationToDeleteIds);

        Task UpdateAsync(RelationBasicInfoDto relationBasicInfoDto);
    }
}
