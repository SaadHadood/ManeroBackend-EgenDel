using ManeroProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductsController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }


        [HttpPost]
        public async Task<IActionResult> Create (ProductSchema schema)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                var requset = new ServiceRequest<ProductSchema> { Content = schema };
                var response = await _productService.CreateAsync(requset);
                return StatusCode((int)response.StatusCode, response);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return Problem();
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = await _productService.GetAllAsync();
                return StatusCode((int)response.StatusCode, response);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return Problem();
            }
        }


        [HttpGet("{articleNumber}")]
        public async Task<IActionResult> GetByArticleNumber(int articleNumber)
        {
            try
            {
                var response = await _productService.GetByArticleNumberAsync(articleNumber);
                return StatusCode((int)response.StatusCode, response);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return Problem();
            }
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ProductSchema productSchema)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                var response = await _productService.UpdateAsync(id, productSchema);
                return StatusCode((int)response.StatusCode, response);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return Problem();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var response = await _productService.DeleteAsync(id);
                return StatusCode((int)response.StatusCode, response);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return Problem();
            }
        }


        [HttpGet("byCategory/{categoryId}")]
        public async Task<IActionResult> GetProductsByCategory(int categoryId)
        {
            try
            {
                // Anropa ICategoryService för att hämta produkterna i kategorin med categoryId
                var productsInCategory = await _categoryService.GetProductsByCategoryAsync(categoryId);

                if (productsInCategory == null)
                {
                    return NotFound(); // Om kategorin inte finns, returnera 404 Not Found
                }

                return Ok(productsInCategory); // Returnera listan med produkter i kategorin
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return Problem();
            }
        }




    }
}
