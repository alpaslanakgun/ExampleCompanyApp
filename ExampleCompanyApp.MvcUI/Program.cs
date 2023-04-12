using Autofac;
using Autofac.Extensions.DependencyInjection;
using ExampleCompanyApp.MvcUI.Modules;
using ExampleCompanyApp.Repository;
using ExampleCompanyApp.Service.Mapping;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using ExampleCompanyApp.Core.Models;
using ExampleCompanyApp.MvcUI.Filters;
using ExampleCompanyApp.MvcUI.Services;
using ExampleCompanyApp.Service.Validations;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<ProductDtoValidator>());
;
builder.Services.AddAutoMapper(typeof(MapProfile));
builder.Services.AddDbContext<ExampleCompanyDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), option =>
    {
        option.MigrationsAssembly(Assembly.GetAssembly(typeof(ExampleCompanyDbContext)).GetName().Name);
    });
});
builder.Services.AddHttpClient<ProductApiService>(opt =>
{
    opt.BaseAddress = new Uri(builder.Configuration["BaseUrl"]);
});
builder.Services.AddHttpClient<CategoryApiService>(opt =>
{
    opt.BaseAddress = new Uri(builder.Configuration["BaseUrl"]);
});
builder.Services.AddScoped(typeof(NotFoundFilter<Product>));
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder => containerBuilder.RegisterModule(new RepoServiceModule()));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
