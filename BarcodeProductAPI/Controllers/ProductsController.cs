using BarcodeProductAPI.Entities;
using BarcodeProductAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BarcodeProductAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("{barcode}")]
        public async Task<IActionResult> GetProductByBarcodeAsync(string barcode)
        {
            var product = await _productService.GetProductByBarcodeAsync(barcode);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }
        [HttpPost]
        public async Task<IActionResult> AddOrUpdateProductAsync([FromBody] Product productDto)
        {
            await _productService.AddOrUpdateProductAsync(productDto.Barcode, productDto.Name, productDto.Price);

            return Ok();
        }
    }
}
