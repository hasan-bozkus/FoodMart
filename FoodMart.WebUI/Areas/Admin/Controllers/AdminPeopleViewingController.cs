using AutoMapper;
using FoodMart.BusinnessLayer.Abstract;
using FoodMart.DtoLayer.Dtos.PeopleViewingDtos;
using FoodMart.EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FoodMart.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminPeopleViewingController : Controller
    {
        private readonly IPeopleViewingService _peopleViewingService;
        private readonly IMapper _mapper;

        public AdminPeopleViewingController(IPeopleViewingService peopleViewingService, IMapper mapper)
        {
            _peopleViewingService = peopleViewingService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var values = _mapper.Map<List<ResultPeopleViewingDto>>(await _peopleViewingService.TGetListAllAsync());
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> CreatePeopleViewing()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreatePeopleViewing(CreatePeopleViewingDto createPeopleViewingDto)
        {
            var result = _mapper.Map<PeopleViewing>(createPeopleViewingDto);
            await _peopleViewingService.TCreateAsync(result);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeletePeopleViewing(string id)
        {
            await _peopleViewingService.TDeleteAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdatePeopleViewing(string id)
        {
            var value = _mapper.Map<UpdatePeopleViewingDto>(await _peopleViewingService.TGetByIdAsync(id));

            var result = await _peopleViewingService.TGetListAllAsync();
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePeopleViewing(UpdatePeopleViewingDto updatePeopleViewingDto)
        {
            var result = _mapper.Map<PeopleViewing>(updatePeopleViewingDto);
            await _peopleViewingService.TUpdateAsync(result);
            return RedirectToAction("Index");
        }
    }
}
