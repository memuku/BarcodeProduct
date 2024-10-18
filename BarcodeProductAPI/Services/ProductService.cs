using BarcodeProductAPI.Data;
using BarcodeProductAPI.Entities;

namespace BarcodeProductAPI.Services
{
    public class ProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> GetProductByBarcodeAsync(string barcode)
        {
            return await _productRepository.GetByBarcodeAsync(barcode);
        }

        public async Task AddOrUpdateProductAsync(string barcode, string name, decimal price)
        {
            var product = await _productRepository.GetByBarcodeAsync(barcode);

            if (product == null)
            {
                product = new Product
                {
                    Barcode = barcode,
                    Name = name,
                    Price = price,
                    CreatedAt = DateTime.UtcNow
                };
                await _productRepository.AddProductAsync(product);
            }
            else
            {
                product.Price = price;
                await _productRepository.UpdateProductAsync(product);
            }
        }

    }
}
