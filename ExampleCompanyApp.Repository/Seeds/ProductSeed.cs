using ExampleCompanyApp.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExampleCompanyApp.Repository.Seeds
{
    public class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product
                {
                    Id = 1,
                    CategoryId = 1,
                    Name = "Apple Iphone 14",
                    Price = 45000,
                    Stock = 250,
                    CreatedDate = DateTime.Now,
                },
                new Product
                {
                    Id = 2,
                    CategoryId = 1,
                    Name = "Apple Iphone 13",
                    Price = 26000,
                    Stock = 20,
                    CreatedDate = DateTime.Now,
                },
                new Product
                {
                    Id = 3,
                    CategoryId = 1,
                    Name = "Apple Iphone 12",
                    Price = 22000,
                    Stock = 50,
                    CreatedDate = DateTime.Now,
                },
                new Product
                {
                    Id = 4,
                    CategoryId = 2,
                    Name = "Dell G15",
                    Price = 35000,
                    Stock = 450,
                    CreatedDate = DateTime.Now,
                },
                new Product
                {
                    Id = 5,
                    CategoryId = 2,
                    Name = "Toshiba SATELLITE",
                    Price = 1000,
                    Stock = 150,
                    CreatedDate = DateTime.Now,
                },
                new Product
                {
                    Id = 6,
                    CategoryId = 3,
                    Name = "Sony Bravia",
                    Price = 65000,
                    Stock = 215,
                    CreatedDate = DateTime.Now,
                },
                new Product
                {
                    Id = 7,
                    CategoryId = 3,
                    Name = "Samsung OLED",
                    Price = 25000,
                    Stock = 173,
                    CreatedDate = DateTime.Now,
                }

                );

        }
    }
}
