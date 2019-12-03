using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using OnionApp.Domain.Models.DTO;
using OnionApp.Domain.Models.Entities;
using OnionApp.Models;
using OnionApp.Models.ViewModels;

namespace OnionApp.Infrastructure.Mapper
{
    public class RelationProfile : Profile
    {
        public RelationProfile()
        {
            CreateMap<Relation, RelationBasicInfoDto>()
                .ForMember(x => x.CountryName, m => m.MapFrom(x => x.RelationAddress.CountryName))
                .ForMember(x => x.City, m => m.MapFrom(x => x.RelationAddress.City))
                .ForMember(x => x.Street, m => m.MapFrom(x => x.RelationAddress.Street))
                .ForMember(x => x.PostalCode, m => m.MapFrom(x => x.RelationAddress.PostalCode))
                .ForMember(x => x.Number, m => m.MapFrom(x => x.RelationAddress.Number))
                .ForMember(x => x.NumberSuffix, m => m.MapFrom(x => x.RelationAddress.NumberSuffix));

            CreateMap<RelationBasicInfoDto, Relation>().ForMember(x => x.RelationAddress, m => m.MapFrom(x => new RelationAddress()
            {
                CountryName = x.CountryName,
                City = x.City,
                Street = x.Street,
                PostalCode = x.PostalCode,
                Number = x.Number,
                NumberSuffix = x.NumberSuffix

            }));

            CreateMap<RelationBasicInfoDto, RelationAddress>();


            CreateMap<RelationInfoViewModel, Relation>()
                .ForMember(x => x.RelationAddress, m => m.MapFrom(x => new RelationAddress()
                {
                    CountryName = x.CountryName,
                    City = x.City,
                    Street = x.Street,
                    PostalCode = x.PostalCode,
                    Number = x.Number,
                    NumberSuffix = x.NumberSuffix

                }));

            CreateMap<RelationBasicInfoDto, RelationInfoViewModel>();

            CreateMap<RelationInfoViewModel, RelationBasicInfoDto>();

            CreateMap<RelationBasicInfoDto, RelationWithAddress>()
                .ForMember(x => x.StreetNumber, m => m.MapFrom(x => x.Number + x.NumberSuffix));

            CreateMap<(IEnumerable<RelationBasicInfoDto>, IEnumerable<CategoryBasicInfoDto>),
                AllRelationsInfoViewModel>().ForMember(x => x.Categories, m => m.MapFrom(z => z.Item2.ToList())).
                ForMember(x => x.Relations, m => m.MapFrom(z => z.Item1));
        }
    }
}
