using AutoMapper;
using FoodMart.BusinnessLayer.Abstract;
using FoodMart.DtoLayer.Dtos.FeatureDtos;
using FoodMart.EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FoodMart.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminFeatureController : Controller
    {
        private readonly IFeatureService _featureService;
        private readonly IMapper _mapper;

        public AdminFeatureController(IFeatureService featureService, IMapper mapper)
        {
            _featureService = featureService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var values = _mapper.Map<List<ResultFeatureDto>>(await _featureService.TGetListAllAsync());
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> CreateFeature()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeature(CreateFeatureDto createFeatureDto)
        {
            var result = _mapper.Map<Feature>(createFeatureDto);
            await _featureService.TCreateAsync(result);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteFeature(string id)
        {
            await _featureService.TDeleteAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateFeature(string id)
        {
            var value = _mapper.Map<UpdateFeatureDto>(await _featureService.TGetByIdAsync(id));

            var result = await _featureService.TGetListAllAsync();
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            var result = _mapper.Map<Feature>(updateFeatureDto);
            await _featureService.TUpdateAsync(result);
            return RedirectToAction("Index");
        }
    }
}
