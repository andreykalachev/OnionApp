using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnionApp.Domain.Interfaces.Services;
using OnionApp.Domain.Models.DTO;
using OnionApp.Models.ViewModels;

namespace OnionApp.Controllers
{
    public class RelationController : Controller
    {
        private readonly ICategoryService _categoryService;

        private readonly ICountryService _countryService;

        private readonly IRelationService _relationService;

        private readonly IMapper _mapper;

        public RelationController(ICategoryService categoryService, ICountryService countryService, IRelationService relationService, IMapper mapper)
        {
            _categoryService = categoryService;
            _countryService = countryService;
            _relationService = relationService;
            _mapper = mapper;
        }

        public async Task<ActionResult> Index()
        {
            var relations = await _relationService.GetAllEnabledBasicInfoAsync();
            var categories = await _categoryService.GetBasicInfoAllAsync();

            var result = _mapper
                .Map<(IEnumerable<RelationBasicInfoDto>, IEnumerable<CategoryBasicInfoDto>), AllRelationsInfoViewModel>
                    ((relations, categories));

            return View("Index", result);
        }
    }
}
