using Microsoft.AspNetCore.Mvc;

namespace FoodMart.WebUI.ViewComponents.UILayout
{
    public class _UILayoutSvgComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
