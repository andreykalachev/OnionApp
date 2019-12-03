using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnionApp.Domain.Interfaces.Services;
using OnionApp.Domain.Models.DTO;
using OnionApp.Domain.Models.Entities;
using OnionApp.Models.ViewModels;
using OnionApp.Utilities;

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

        public async Task<ActionResult> Index(string sortOrder = null)
        {
            var relations = await _relationService.GetAllEnabledBasicInfoAsync();
            var categories = await _categoryService.GetBasicInfoAllAsync();

            relations = relations.RelationOrderBy(sortOrder);

            var result = _mapper
                .Map<(IEnumerable<RelationBasicInfoDto>, IEnumerable<CategoryBasicInfoDto>), AllRelationsInfoViewModel>
                    ((relations, categories));

            return View("Index", result);
        }

        public async Task<ActionResult> GetRelationsByCategory(Guid categoryId)
        {
            var relations = await _relationService.GetAllEnabledByCategoryIdAsync(categoryId);
            var categories = await _categoryService.GetBasicInfoAllAsync();

            var result = _mapper
                .Map<(IEnumerable<RelationBasicInfoDto>, IEnumerable<CategoryBasicInfoDto>), AllRelationsInfoViewModel>
                    ((relations, categories));

            return View("Index", result);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(RelationInfoViewModel relationInfoViewModel)
        {
            var relation = _mapper.Map<RelationInfoViewModel, Relation>(relationInfoViewModel);
            await _relationService.CreateAsync(relation);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Edit(Guid id)
        {
            var relation = await _relationService.GetByIdAsync(id);

            if (relation == null)
            {
                return NotFound();
            }

            var result = _mapper.Map<RelationBasicInfoDto, RelationInfoViewModel>(relation);

            return View("Edit", result);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(RelationInfoViewModel relation)
        {
            await _relationService.UpdateAsync(_mapper.Map<RelationInfoViewModel, RelationBasicInfoDto>(relation));

            return RedirectToAction("Index");
        }


        public async Task<ActionResult> Delete(Guid id)
        {
            await _relationService.DisableAsync(id);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<ActionResult> DeleteRange(string ids)
        {
            var parsedIds = JsonParser.ParseStringToIEnumerableGuids(ids);
            await _relationService.DisableRangeAsync(parsedIds);

            return Ok();
        }
    }
}
