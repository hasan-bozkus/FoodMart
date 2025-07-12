using FoodMart.BusinnessLayer.Abstract;
using FoodMart.BusinnessLayer.Concrete;
using FoodMart.BusinnessLayer.ExternalServices;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodMart.BusinnessLayer
{
    public static class ServiceRegistration
    {
        public static void AddBusinnessLayerServices(this IServiceCollection service)
        {
            service.AddScoped<IAdminService, AdminManager>();
            service.AddScoped<ICategoryService, CategoryManager>();
            service.AddScoped<ICustomerService, CustomerManager>();
            service.AddScoped<IDiscountService, DiscountManager>();
            service.AddScoped<IFeatureService, FeatureManager>();
            service.AddScoped<IPeopleViewingService, PeopleViewingManager>();
            service.AddScoped<IProductService, ProductManager>();

            service.AddScoped<SendEmailService>();
        }
    }
}
