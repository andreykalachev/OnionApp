using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using OnionApp.Domain.Interfaces;
using OnionApp.Domain.Interfaces.Repositories;
using OnionApp.Domain.Interfaces.Services;
using OnionApp.Domain.Models.DTO;

namespace OnionApp.Domain.Services
{
    public class CountryService : ICountryService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICountryRepository _repository;

        public CountryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _repository = unitOfWork.CountryRepository;
        }

        public async Task<IEnumerable<CountryBasicInfoDto>> GetAllEnabledBasicInfoAsync()
        {
            var allCountries = await _repository.GetAllAsync();

            return _mapper.Map<IEnumerable<CountryBasicInfoDto>>(allCountries);
        }

        public async Task<string> GetPostalCodeFormatAsync(Guid id)
        {
            var country = await _repository.FindAsync(x => x.Id == id);

            return country.PostalCodeFormat;
        }
    }
}
