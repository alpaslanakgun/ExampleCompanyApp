using AutoMapper;
using ExampleCompanyApp.Core.DTOs;
using ExampleCompanyApp.Core.Models;
using ExampleCompanyApp.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExampleCompanyApp.API.Controllers
{

    public class ProductsController :BaseController
    {

        private readonly IMapper _mapper;
   
        private readonly IProductService _service;

        public ProductsController(IMapper mapper, IService<Product> service, IProductService productService)
        {
            _mapper = mapper;
            _service = productService;
           
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _service.GetAllAsync();

            var productsDtos=_mapper.Map<List<ProductDto>>(products.ToList());

         
            return CreateActionResult(CustomResponseDto<List<ProductDto>>.Success(200,productsDtos));
        }

        [HttpGet("GetProductWithCategory")]
        public async Task<IActionResult> GetProductWithCategory()
        {
            return CreateActionResult(await _service.GetProductWithCategoryAsync());

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _service.GetByIdAsync(id);

            var productsDtos = _mapper.Map<ProductDto>(product);


            return CreateActionResult(CustomResponseDto<ProductDto>.Success(200, productsDtos));
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductDto productDto)
        {
            var product = await _service.AddAsync(_mapper.Map<Product>(productDto));
            var productsDto =_mapper.Map<ProductDto>(product);

            return CreateActionResult(CustomResponseDto<ProductDto>.Success(201, productsDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateDto productUpdateDto)
        {
            await _service.UpdateAsync(_mapper.Map<Product>(productUpdateDto));
        

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _service.GetByIdAsync(id); 
            await _service.RemoveAsync(product);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }


    }
}
