using System.Collections.Generic;
using AutoMapper;
using OnionApp.Domain.Models.DTO;
using OnionApp.Domain.Models.Entities;

namespace OnionApp.Infrastructure.Mapper
{
    public class CountryProfile : Profile
    {
        public CountryProfile()
        {
            CreateMap<Country, CountryBasicInfoDto>();

            CreateMap<CountryBasicInfoDto, Country>();

            CreateMap<IEnumerable<Country>, IEnumerable<CountryBasicInfoDto>>();
        }
    }
}
