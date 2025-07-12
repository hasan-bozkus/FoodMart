using Microsoft.AspNetCore.Mvc;

namespace FoodMart.WebUI.Areas.Admin.ViewComponents.AdminLayout
{
    public class _AdminLayoutHeadComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
