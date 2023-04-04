using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ExampleCompanyApp.Core.DTOs;
using ExampleCompanyApp.Core.Models;
using ExampleCompanyApp.Core.Repositories;
using ExampleCompanyApp.Core.Services;
using ExampleCompanyApp.Core.UnitOfWorks;

namespace ExampleCompanyApp.Service.Services
{
    public class CategoryService:Service<Category>,ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(IGenericRepository<Category> repository, IUnitOfWork unitOfWork, ICategoryRepository categoryRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<CategoryWithProductDto>> GetSingleCategoryIdWithProductsAsync(int categoryId)
        {
            var category= await _categoryRepository.GetSingleCategoryIdWithProductsAsync(categoryId);
           var categoryDto= _mapper.Map<CategoryWithProductDto>(category);
           return CustomResponseDto<CategoryWithProductDto>.Success(200, categoryDto);
        }
    }
}
