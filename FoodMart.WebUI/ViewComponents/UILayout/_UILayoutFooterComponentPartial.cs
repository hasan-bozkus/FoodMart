using Microsoft.AspNetCore.Mvc;

namespace FoodMart.WebUI.ViewComponents.UILayout
{
    public class _UILayoutFooterComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
