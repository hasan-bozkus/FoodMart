using FoodMart.BusinnessLayer.ExternalServices;
using FoodMart.DtoLayer.Dtos.MailDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FoodMart.WebUI.Controllers
{
    [AllowAnonymous]
    public class UILayoutController : Controller
    {
        public IActionResult _UILayout()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendEmail(CreateSendEmailDto createSendEmailDto)
        {
           var sendEmail = new SendEmailService();
            var values = await sendEmail.SendEmailAsync(createSendEmailDto);
            TempData["Success"] = values;
            return RedirectToAction("_UILayout");
        }
    }
}
