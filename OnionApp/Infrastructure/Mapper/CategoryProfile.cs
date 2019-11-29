using System.Collections.Generic;
using AutoMapper;
using OnionApp.Domain.Models.DTO;
using OnionApp.Domain.Models.Entities;

namespace OnionApp.Infrastructure.Mapper
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryBasicInfoDto>();

            CreateMap<CategoryBasicInfoDto, Category>();

            CreateMap<IEnumerable<Category>, IEnumerable<CategoryBasicInfoDto>>();
        }
    }
}