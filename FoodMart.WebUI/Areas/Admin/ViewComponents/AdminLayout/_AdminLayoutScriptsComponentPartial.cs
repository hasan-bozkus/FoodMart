using Microsoft.AspNetCore.Mvc;

namespace FoodMart.WebUI.Areas.Admin.ViewComponents.AdminLayout
{
    public class _AdminLayoutScriptsComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
