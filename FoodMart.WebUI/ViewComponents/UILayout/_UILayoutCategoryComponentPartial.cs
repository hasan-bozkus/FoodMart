using AutoMapper;
using FoodMart.BusinnessLayer.Abstract;
using FoodMart.DtoLayer.Dtos.CategoryDtos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FoodMart.WebUI.ViewComponents.UILayout
{
    public class _UILayoutCategoryComponentPartial : ViewComponent
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public _UILayoutCategoryComponentPartial(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = _mapper.Map<List<ResultCategoryDto>>(await _categoryService.TGetListAllAsync());
            return View(values);
        }
    }
}
