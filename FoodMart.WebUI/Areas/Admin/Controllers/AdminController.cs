using AutoMapper;
using FoodMart.BusinnessLayer.Abstract;
using FoodMart.DtoLayer.Dtos.AdminDtos;
using FoodMart.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FoodMart.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;
        private readonly IMapper _mapper;

        public AdminController(IAdminService adminService, IMapper mapper)
        {
            _adminService = adminService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(CreateRegisterDto createRegisterDto)
        {

            if (string.IsNullOrEmpty(createRegisterDto.Username) || string.IsNullOrEmpty(createRegisterDto.Password))
            {
                ModelState.AddModelError("", "Kullanıcı adı ve şifre gerekli.");
                return View(createRegisterDto);
            }


            var result = _mapper.Map<AppUser>(createRegisterDto);

            if (createRegisterDto.ImageUrl != null)
            {
                var exstension = Path.GetExtension(createRegisterDto.ImageUrl.FileName);
                var newwriterimage = Guid.NewGuid() + exstension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserImageFiles/", newwriterimage);
                var stream = new FileStream(location, FileMode.Create);
                createRegisterDto.ImageUrl.CopyTo(stream);
                result.ImageUrl = newwriterimage;
            }

            await _adminService.TRegisterUserAsync(result);
            TempData["SuccessMessage"] = "Kayıt başarılı, giriş yapabilirsiniz.";
            return RedirectToAction("Login");
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            var user = await _adminService.TGetUserByUsernameAsync(username);
            if (user == null || !await _adminService.TCheckPasswordAsync(user, password))
            {
                ModelState.AddModelError("", "Geçersiz kullanıcı adı veya şifre.");
                return View();
            }

            HttpContext.Session.SetString("AppUserId", user.AppUserId);
            return RedirectToAction("Index", "AdminCategory");
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Admin");
        }
    }
}
