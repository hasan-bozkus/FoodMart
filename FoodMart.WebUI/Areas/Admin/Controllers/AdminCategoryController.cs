using AutoMapper;
using FoodMart.BusinnessLayer.Abstract;
using FoodMart.DtoLayer.Dtos.CategoryDtos;
using FoodMart.EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FoodMart.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminCategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public AdminCategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var values = _mapper.Map<List<ResultCategoryDto>>(await _categoryService.TGetListAllAsync());
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            var result = _mapper.Map<Category>(createCategoryDto);
            await _categoryService.TCreateAsync(result);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteCategory(string id)
        {
            await _categoryService.TDeleteAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCategory(string id)
        {
            var value = _mapper.Map<UpdateCategoryDto>(await _categoryService.TGetByIdAsync(id));
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            var result = _mapper.Map<Category>(updateCategoryDto);
            await _categoryService.TUpdateAsync(result);
            return RedirectToAction("Index");
        }
    }
}
