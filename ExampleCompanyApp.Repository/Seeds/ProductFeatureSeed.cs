using ExampleCompanyApp.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExampleCompanyApp.Repository.Seeds
{
    public class ProductFeatureSeed : IEntityTypeConfiguration<ProductFeature>
    {
        public void Configure(EntityTypeBuilder<ProductFeature> builder)
        {
            builder.HasData(new ProductFeature
            {

                Id = 1,
                Color = "Blue",
                Height = 150,
                Width = 150,
                ProductId = 1

            },
                new ProductFeature
                {

                    Id = 2,
                    Color = "Black",
                    Height = 300,
                    Width = 500,
                    ProductId = 2

                });
        }
    }
}
