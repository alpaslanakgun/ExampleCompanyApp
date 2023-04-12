using ExampleCompanyApp.Core.Models;
using ExampleCompanyApp.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ExampleCompanyApp.Repository.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(ExampleCompanyDbContext context) : base(context)
        {
        }

        public async Task<List<Product>> GetProductWithCategoryAsync()
        {

            return await _context.Products.Include(x => x.Category).ToListAsync();
        }
    }
}
