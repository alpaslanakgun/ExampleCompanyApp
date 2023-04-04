

using AutoMapper;
using ExampleCompanyApp.Core.DTOs;
using ExampleCompanyApp.Core.Models;
using ExampleCompanyApp.Core.Repositories;
using ExampleCompanyApp.Core.Services;
using ExampleCompanyApp.Core.UnitOfWorks;

namespace ExampleCompanyApp.Service.Services
{
    public class ProductService:Service<Product>,IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductService(IGenericRepository<Product> repository, IUnitOfWork unitOfWork,  IMapper mapper, IProductRepository productRepository) : base(repository, unitOfWork)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<CustomResponseDto<List<ProductWithCategoryDto>>> GetProductWithCategoryAsync()
        {
            var product = await _productRepository.GetProductWithCategoryAsync();
            var productDto = _mapper.Map<List<ProductWithCategoryDto>> (product);
            return CustomResponseDto<List<ProductWithCategoryDto>>.Success(200, productDto);

        }
    }
}
