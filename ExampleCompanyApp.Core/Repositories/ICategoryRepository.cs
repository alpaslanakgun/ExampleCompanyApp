using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExampleCompanyApp.Core.Models;

namespace ExampleCompanyApp.Core.Repositories
{
    public interface ICategoryRepository:IGenericRepository<Category>
    {

        Task<Category> GetSingleCategoryIdWithProductsAsync(int categoryId);


    }
}
