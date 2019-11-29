using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using OnionApp.Domain.Interfaces;
using OnionApp.Domain.Interfaces.Repositories;
using OnionApp.Domain.Interfaces.Services;
using OnionApp.Domain.Models.DTO;

namespace OnionApp.Domain.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICategoryRepository _repository;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _repository = _unitOfWork.CategoryRepository;
        }

        public async Task<IEnumerable<CategoryBasicInfoDto>> GetBasicInfoAllAsync()
        {
            var allCategories = await _repository.GetAllAsync();

            return _mapper.Map<IEnumerable<CategoryBasicInfoDto>>(allCategories);
        }
    }
}
