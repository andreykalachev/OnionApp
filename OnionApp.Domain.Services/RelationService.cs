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
using OnionApp.Domain.Services.Utilities;

namespace OnionApp.Domain.Services
{
    public class RelationService : IRelationService
    {
        private readonly IRelationRepository _repository;
        private readonly ICountryService _countryService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RelationService(IUnitOfWork unitOfWork, IMapper mapper, ICountryService countryService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _countryService = countryService;
            _repository = _unitOfWork.RelationRepository;
        }

        public async Task<RelationBasicInfoDto> GetByIdAsync(Guid id)
        {
            var relation = await _repository.FindAsync(x => x.Id == id);

            return _mapper.Map<RelationBasicInfoDto>(relation);
        }

        public async Task<IEnumerable<RelationBasicInfoDto>> GetAllEnabledBasicInfoAsync()
        {
            var relation = await _repository.GetAllAsync(x => !x.IsDisabled);

            return _mapper.Map<IEnumerable<RelationBasicInfoDto>>(relation);
        }

        public async Task<IEnumerable<RelationBasicInfoDto>> GetAllEnabledByCategoryIdAsync(Guid categoryId)
        {
            var relations = await _repository.GetAllAsync(x => x.RelationCategories.Any(c => c.CategoryId == categoryId) && x.IsDisabled == false);

            return _mapper.Map<IEnumerable<RelationBasicInfoDto>>(relations);
        }

        public async Task CreateAsync(Relation relation)
        {
            var address = relation.RelationAddress;
            var postalCodeMask = await _countryService.GetPostalCodeFormatByCountryNameAsync(address.CountryName);

            var parsedPostalCode = PostCodeParser.Parse(address.PostalCode, postalCodeMask);
            relation.RelationAddress.PostalCode = parsedPostalCode;

            _repository.Add(relation);
            _unitOfWork.RelationAddressRepository.Add(relation.RelationAddress);

            await _unitOfWork.CommitAsync();
        }

        public async Task DisableAsync(Guid id)
        {
            var relation = await _repository.FindAsync(x => x.Id == id);

            if (relation != null)
            {
                relation.IsDisabled = true;
                await _unitOfWork.CommitAsync();
            }
        }

        public async Task DisableRangeAsync(IEnumerable<Guid> relationToDeleteIds)
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
            var address = await _unitOfWork.RelationAddressRepository.FindAsync(x => x.RelationId == relationBasicInfoDto.Id) ?? new RelationAddress();

            if (relation != null)
            {
                _mapper.Map(relationBasicInfoDto, relation);

                var postalCodeMask = await _countryService.GetPostalCodeFormatByCountryNameAsync(address.CountryName);
                var parsedPostalCode = PostCodeParser.Parse(relationBasicInfoDto.PostalCode, postalCodeMask);
                relationBasicInfoDto.PostalCode = parsedPostalCode;

                _mapper.Map(relationBasicInfoDto, relation.RelationAddress);

                _unitOfWork.RelationAddressRepository.Update(relation.RelationAddress);
                _repository.Update(relation);
                await _unitOfWork.CommitAsync();
            }
        }
    }
}
