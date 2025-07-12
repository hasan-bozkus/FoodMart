using AutoMapper;
using FoodMart.BusinnessLayer.Abstract;
using FoodMart.DtoLayer.Dtos.ProductDtos;
using FoodMart.EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace FoodMart.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public AdminProductController(IProductService productService, IMapper mapper, ICategoryService categoryService)
        {
            _productService = productService;
            _mapper = mapper;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var values = _mapper.Map<List<ResultProductWithCategoryDto>>(await _productService.TGetAllProductWithCategoryAsync());
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            var result = await _categoryService.TGetListAllAsync();
            List<SelectListItem> categoryValues = (from x in result
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryId
                                                   }).ToList();

            ViewBag.CategoryValues = categoryValues;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            var result = _mapper.Map<Product>(createProductDto);
            await _productService.TCreateAsync(result);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _productService.TDeleteAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProduct(string id)
        {
            var value = _mapper.Map<UpdateProductDto>(await _productService.TGetByIdAsync(id));

            var result = await _categoryService.TGetListAllAsync();
            List<SelectListItem> categoryValues = (from x in result
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryId
                                                   }).ToList();

            ViewBag.CategoryValues = categoryValues;

            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            var result = _mapper.Map<Product>(updateProductDto);
            await _productService.TUpdateAsync(result);
            return RedirectToAction("Index");
        }
    }
}
