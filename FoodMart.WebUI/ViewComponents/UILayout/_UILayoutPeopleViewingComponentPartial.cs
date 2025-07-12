using AutoMapper;
using FoodMart.BusinnessLayer.Abstract;
using FoodMart.DtoLayer.Dtos.PeopleViewingDtos;
using Microsoft.AspNetCore.Mvc;

namespace FoodMart.WebUI.ViewComponents.UILayout
{
    public class _UILayoutPeopleViewingComponentPartial : ViewComponent
    {
        private readonly IPeopleViewingService _peopleViewingService;
        private readonly IMapper _mapper;

        public _UILayoutPeopleViewingComponentPartial(IPeopleViewingService peopleViewingService, IMapper mapper)
        {
            _peopleViewingService = peopleViewingService;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = _mapper.Map<List<ResultPeopleViewingDto>>(await _peopleViewingService.TGetListAllAsync());
            return View(values);
        }
    }
}
