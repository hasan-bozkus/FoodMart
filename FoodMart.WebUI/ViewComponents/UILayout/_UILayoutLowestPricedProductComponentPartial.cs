using AutoMapper;
using FoodMart.BusinnessLayer.Abstract;
using FoodMart.DtoLayer.Dtos.ProductDtos;
using Microsoft.AspNetCore.Mvc;

namespace FoodMart.WebUI.ViewComponents.UILayout
{
    public class _UILayoutLowestPricedProductComponentPartial : ViewComponent
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public _UILayoutLowestPricedProductComponentPartial(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var products = _mapper.Map<List<ResultProductDto>>(await _productService.TGetListAllAsync());
            if(products == null)
            {
                products = new List<ResultProductDto>();
            }

            var values = products.OrderBy(p => p.Price).Take(6).ToList();
            return View(values);
        }
    }
}
