using FoodMart.DataAccessLayer.Abstract;
using FoodMart.DataAccessLayer.Concrete;
using FoodMart.DataAccessLayer.ExternalProcess;
using FoodMart.DataAccessLayer.MongoDb;
using FoodMart.DataAccessLayer.Settings;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodMart.DataAccessLayer
{
    public static class ServiceRegistration
    {
        public static void AddDataAccessLayerServices(this IServiceCollection services)
        {
            services.AddScoped<FoodMartContext>();
            services.AddScoped<IDatabaseSettingsKey, DatabaseSettingsKey>();
                    
            services.AddScoped<IAdminDal, MGAdminRepository>();
            services.AddScoped<ICategoryDal, MGCategoryRepository>();
            services.AddScoped<ICustomerDal, MGCustomerRepository>();
            services.AddScoped<IDiscountDal, MGDiscountRepository>();
            services.AddScoped<IFeatureDal, MGFeatureRepository>();
            services.AddScoped<IPeopleViewingDal, MGPeopleViewingRepository>();
            services.AddScoped<IProductDal, MGProductRepository>();

            services.AddScoped<SendEmailProcess>();
        }
    }
}
