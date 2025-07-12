
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FoodMart.WebUI.Settings
{
    public class AuthRequiredFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // Eğer istek zaten [AllowAnonymous] ile işaretlenmişse (action veya controller düzeyinde), filtreyi atla.
            // Bu, döngüyü kıracak olan mekanizmadır.
            var endpoint = context.HttpContext.GetEndpoint();
            if (endpoint?.Metadata.GetMetadata<IAllowAnonymous>() != null)
            {
                return; // Yetkilendirme kontrolünü atla
            }

            // Eğer kullanıcı session'da "AppUserId" key'ine sahip değilse
            if (string.IsNullOrEmpty(context.HttpContext.Session.GetString("AppUserId")))
            {
                // İstek henüz işlenmeden yetkisiz olduğunu belirt
                // Bu, kullanıcıyı giriş sayfasına yönlendirir
                context.Result = new RedirectToActionResult("Login", "Admin", new { area = "Admin" } , null);
                return;
            }

        }
    }
}
