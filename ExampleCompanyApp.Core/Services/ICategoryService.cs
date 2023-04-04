using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExampleCompanyApp.Core.DTOs;
using ExampleCompanyApp.Core.Models;

namespace ExampleCompanyApp.Core.Services
{
    public interface ICategoryService:IService<Category>
    {

        public Task<CustomResponseDto<CategoryWithProductDto>> GetSingleCategoryIdWithProductsAsync(int categoryId);

    }
}
