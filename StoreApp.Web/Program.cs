using Microsoft.EntityFrameworkCore;
using StoreApp.Data.Abstract;
using StoreApp.Data.Concrete;
using StoreApp.Web.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddAutoMapper(typeof(MapperProfile).Assembly);

builder.Services.AddDbContext<StoreDbContext>(
    o => o.UseSqlite(builder.Configuration.GetConnectionString("StoreDbConnection"),b=>b.MigrationsAssembly("StoreApp.Web")));

builder.Services.AddScoped<IStoreRepository,EfStoreRepository>();

var app = builder.Build();

app.UseStaticFiles();
app.MapControllerRoute(
    name: "products_in_category",
    pattern: "/products/{category?}",
    defaults: new { controller = "Home", action = "Index" });
app.MapControllerRoute(
    name: "product_details",
    pattern: "{name}",
    defaults: new { controller = "Home", action = "Details" });


app.MapDefaultControllerRoute();
app.Run();
