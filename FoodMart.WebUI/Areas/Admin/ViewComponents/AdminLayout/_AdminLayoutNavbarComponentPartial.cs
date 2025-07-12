using Microsoft.AspNetCore.Mvc;

namespace FoodMart.WebUI.Areas.Admin.ViewComponents.AdminLayout
{
    public class _AdminLayoutNavbarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
