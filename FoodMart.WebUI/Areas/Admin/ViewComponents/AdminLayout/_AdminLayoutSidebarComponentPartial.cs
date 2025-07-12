using Microsoft.AspNetCore.Mvc;

namespace FoodMart.WebUI.Areas.Admin.ViewComponents.AdminLayout
{
    public class _AdminLayoutSidebarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
