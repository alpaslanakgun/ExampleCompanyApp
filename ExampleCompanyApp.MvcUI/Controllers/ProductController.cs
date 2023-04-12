
using ExampleCompanyApp.Core.DTOs;
using ExampleCompanyApp.Core.Models;
using ExampleCompanyApp.MvcUI.Filters;
using ExampleCompanyApp.MvcUI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace ExampleCompanyApp.MvcUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductApiService _productApiService;
        private readonly CategoryApiService _categoryApiService;

        public ProductController(CategoryApiService categoryApiService, ProductApiService productApiService)
        {
            _categoryApiService = categoryApiService;
            _productApiService = productApiService;
        }

        public async Task<IActionResult> Index()
        
        {

            return View(await _productApiService.GetProductWithCategoryAsync());
        }

        public async Task<IActionResult> Add()
        {
            var categoriesDto = await _categoryApiService.GetAllAsync();



            ViewBag.Categories = new SelectList(categoriesDto, "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductDto productDto)

        {


            if (ModelState.IsValid)
            {

                await _productApiService.AddAsync(productDto);


                return RedirectToAction(nameof(Index));
            }

            var categoriesDto = await _categoryApiService.GetAllAsync();



            ViewBag.Categories = new SelectList(categoriesDto, "Id", "Name");
            return View();
        }


        [ServiceFilter(typeof(NotFoundFilter<Product>))]
        public async Task<IActionResult> Update(int id)
        {
            var product = await _productApiService.GetByIdAsync(id);


            var categoriesDto = await _categoryApiService.GetAllAsync();



            ViewBag.Categories = new SelectList(categoriesDto, "Id", "Name", product.CategoryId);

            return View(product);

        }
        [HttpPost]
        public async Task<IActionResult> Update(ProductDto productDto)
        {
            if (ModelState.IsValid)
            {

                await _productApiService.UpdateAsync(productDto);

                return RedirectToAction(nameof(Index));

            }

            var categoriesDto = await _categoryApiService.GetAllAsync();



            ViewBag.Categories = new SelectList(categoriesDto, "Id", "Name", productDto.CategoryId);

            return View(productDto);

        }


        public async Task<IActionResult> Delete(int id)
        {
            await _productApiService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
