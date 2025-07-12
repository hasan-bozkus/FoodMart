using FoodMart.BusinnessLayer;
using FoodMart.DataAccessLayer;
using FoodMart.DataAccessLayer.Settings;
using FoodMart.WebUI.Settings;
using Microsoft.Extensions.Options;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddBusinnessLayerServices();
builder.Services.AddDataAccessLayerServices();
builder.Services.Configure<DatabaseSettingsKey>(builder.Configuration.GetSection("DatabaseSettingsKey"));

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

// Add services to the container.
builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add(new AuthRequiredFilter());
});
builder.Services.AddSession();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSession();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=UILayout}/{action=_UILayout}/{id?}");

app.Run();
