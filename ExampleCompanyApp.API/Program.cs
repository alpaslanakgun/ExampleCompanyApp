using System.Reflection;
using ExampleCompanyApp.API.Filters;
using ExampleCompanyApp.API.Middlewares;
using ExampleCompanyApp.Core.Repositories;
using ExampleCompanyApp.Core.Services;
using ExampleCompanyApp.Core.UnitOfWorks;
using ExampleCompanyApp.Repository;
using ExampleCompanyApp.Repository.Repositories;
using ExampleCompanyApp.Repository.UnitOfWorks;
using ExampleCompanyApp.Service.Mapping;
using ExampleCompanyApp.Service.Services;
using ExampleCompanyApp.Service.Validations;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options => options.Filters.Add(new ValidaterFilter())).AddFluentValidation(x=>x.RegisterValidatorsFromAssemblyContaining<ProductDtoValidator>());

//This code snippet is configuring the behavior of the ASP.NET Core API regarding model validation errors.
//Bu kod par�as�, ASP.NET Core API'nin model do�rulama hatalar�yla ilgili davran���n� yap�land�rmak i�in kullan�l�r.
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter=true;
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IService<>),typeof(Service<>));
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService,CategoryService>(); 
builder.Services.AddScoped<ICategoryRepository,CategoryRepository>();
builder.Services.AddAutoMapper(typeof(MapProfile));


builder.Services.AddDbContext<ExampleCompanyDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), option =>
    {
        option.MigrationsAssembly(Assembly.GetAssembly(typeof(ExampleCompanyDbContext)).GetName().Name);
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UserCustomException();

app.UseAuthorization();

app.MapControllers();

app.Run();
