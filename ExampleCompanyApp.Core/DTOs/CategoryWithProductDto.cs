namespace ExampleCompanyApp.Core.DTOs
{
    public class CategoryWithProductDto : CategoryDto
    {
        public List<ProductDto> Products { get; set; }
    }
}
