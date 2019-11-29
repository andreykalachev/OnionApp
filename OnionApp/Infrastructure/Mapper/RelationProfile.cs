using System.Collections.Generic;
using AutoMapper;
using OnionApp.Domain.Models.DTO;
using OnionApp.Domain.Models.Entities;
using OnionApp.Models.ViewModels;

namespace OnionApp.Infrastructure.Mapper
{
    public class RelationProfile : Profile
    {
        public RelationProfile()
        {
            CreateMap<Relation, RelationBasicInfoDto>();

            CreateMap<RelationBasicInfoDto, Relation>();

            CreateMap<IEnumerable<Relation>, IEnumerable<RelationBasicInfoDto>>();

            CreateMap<(IEnumerable<RelationBasicInfoDto>, IEnumerable<CategoryBasicInfoDto>),
                AllRelationsInfoViewModel>();
        }
    }
}
