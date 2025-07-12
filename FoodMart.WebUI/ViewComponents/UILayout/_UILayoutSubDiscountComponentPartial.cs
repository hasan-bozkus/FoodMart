using AutoMapper;
using FoodMart.BusinnessLayer.Abstract;
using FoodMart.DtoLayer.Dtos.DiscountDtos;
using Microsoft.AspNetCore.Mvc;

namespace FoodMart.WebUI.ViewComponents.UILayout
{
    public class _UILayoutSubDiscountComponentPartial : ViewComponent
    {
        private readonly IDiscountService _discountService;
        private readonly IMapper _mapper;

        public _UILayoutSubDiscountComponentPartial(IDiscountService discountService, IMapper mapper)
        {
            _discountService = discountService;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var discount = _mapper.Map<List<ResultDiscountDto>>(await _discountService.TGetListAllAsync());
            var values = discount.OrderBy(x => x.DiscountId).Take(2).ToList();
            return View(values);
        }
    }
}
