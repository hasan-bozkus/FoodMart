using AutoMapper;
using FoodMart.BusinnessLayer.Abstract;
using FoodMart.DtoLayer.Dtos.DiscountDtos;
using FoodMart.EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FoodMart.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminDiscountController : Controller
    {
        private readonly IDiscountService _discountService;
        private readonly IMapper _mapper;

        public AdminDiscountController(IDiscountService discountService, IMapper mapper)
        {
            _discountService = discountService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var values = _mapper.Map<List<ResultDiscountDto>>(await _discountService.TGetListAllAsync());
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> CreateDiscount()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateDiscount(CreateDiscountDto createDiscountDto)
        {
            var result = _mapper.Map<Discount>(createDiscountDto);
            await _discountService.TCreateAsync(result);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteDiscount(string id)
        {
            await _discountService.TDeleteAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateDiscount(string id)
        {
            var value = _mapper.Map<UpdateDiscountDto>(await _discountService.TGetByIdAsync(id));

            var result = await _discountService.TGetListAllAsync();
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDiscount(UpdateDiscountDto updateDiscountDto)
        {
            var result = _mapper.Map<Discount>(updateDiscountDto);
            await _discountService.TUpdateAsync(result);
            return RedirectToAction("Index");
        }
    }
}
