using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using OnionApp.Domain.Interfaces;
using OnionApp.Domain.Interfaces.Repositories;
using OnionApp.Domain.Interfaces.Services;
using OnionApp.Domain.Models.DTO;
using OnionApp.Domain.Models.Entities;

namespace OnionApp.Domain.Services
{
    public class RelationService : IRelationService
    {
        private readonly IRelationRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RelationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _repository = _unitOfWork.RelationRepository;
        }

        public async Task<RelationBasicInfoDto> GetASync(Guid id)
        {
            var relation = await _repository.FindAsync(x => x.Id == id);

            return _mapper.Map<RelationBasicInfoDto>(relation);
        }

        public async Task<IEnumerable<RelationBasicInfoDto>> GetAllEnabledBasicInfoAsync()
        {
            var relation = await _repository.GetAllAsync(x => x.IsDisabled == false);

            return _mapper.Map<IEnumerable<RelationBasicInfoDto>>(relation);
        }

        public async Task<IEnumerable<RelationBasicInfoDto>> GetAllEnabledOfCategoryAsync(Guid categoryId)
        {
            var relations = await _repository.GetAllAsync(x => x.Categories.Any(c => c.Id == categoryId) && x.IsDisabled == false);

            return _mapper.Map<IEnumerable<RelationBasicInfoDto>>(relations);
        }

        public async Task AddAsync(Relation relation)
        {
            _repository.Add(relation);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var relation = await _repository.FindAsync(x => x.Id == id);

            if (relation != null)
            {
                relation.IsDisabled = true;
                await _unitOfWork.CommitAsync();
            }
        }

        public async Task DeleteRangeAsync(IEnumerable<Guid> relationToDeleteIds)
        {
            foreach (var id in relationToDeleteIds)
            {
                var relation = await _repository.FindAsync(x => x.Id == id);

                if (relation != null)
                {
                    relation.IsDisabled = true;
                }
            }

            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(RelationBasicInfoDto relationBasicInfoDto)
        {
            var relation = await _repository.FindAsync(x => x.Id == relationBasicInfoDto.Id);

            if (relation != null)
            {
                 _mapper.Map(relationBasicInfoDto, relation);

                _repository.Update(relation);
                await _unitOfWork.CommitAsync();
            }
        }
    }
}
