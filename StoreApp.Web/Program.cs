using Microsoft.EntityFrameworkCore;
using StoreApp.Data.Abstract;
using StoreApp.Data.Concrete;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<StoreDbContext>(
    o => o.UseSqlite(builder.Configuration.GetConnectionString("StoreDbConnection"),b=>b.MigrationsAssembly("StoreApp.Web")));

builder.Services.AddScoped<IStoreRepository,EfStoreRepository>();

var app = builder.Build();

app.UseStaticFiles();
app.MapDefaultControllerRoute();


app.Run();
