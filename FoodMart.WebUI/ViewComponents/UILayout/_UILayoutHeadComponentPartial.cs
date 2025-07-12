using Microsoft.AspNetCore.Mvc;

namespace FoodMart.WebUI.ViewComponents.UILayout
{
    public class _UILayoutHeadComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
