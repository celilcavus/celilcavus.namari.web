using _01_EntityLayer;
using _02_DataAccess;
using _02_DataAccess.Interfaces;
using _02_DataAccess.Repository;
using FluentValidation.AspNetCore;
using Namari.FluentValidation;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();


builder.Services.AddScoped<IClientsRepository, ClientsRepository>();
builder.Services.AddScoped<IAboutRepository, AboutRepository>();
builder.Services.AddScoped<ApplicationContext, ApplicationContext>();
builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IServicesRepository, ServicesRepository>();
builder.Services.AddScoped<IGalleryRepository, GalleryRepository>();
var app = builder.Build();




app.UseStaticFiles();

app.UseHttpsRedirection();
app.UseRouting();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
    );

app.Run();
