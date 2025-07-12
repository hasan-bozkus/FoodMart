using AutoMapper;
using FoodMart.BusinnessLayer.Abstract;
using FoodMart.DtoLayer.Dtos.DiscountDtos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FoodMart.WebUI.ViewComponents.UILayout
{
    public class _UILayoutDiscountComponentPartial : ViewComponent
    {
        private readonly IDiscountService _discountService;
        private readonly IMapper _mapper;

        public _UILayoutDiscountComponentPartial(IDiscountService discountService, IMapper mapper)
        {
            _discountService = discountService;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var discounts = _mapper.Map<List<ResultDiscountDto>>(await _discountService.TGetListAllAsync());
            var values = discounts.Skip(Math.Max(0, discounts.Count - 2)).ToList();
            return View(values);
        }
    }
}
