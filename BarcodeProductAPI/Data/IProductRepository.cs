using BarcodeProductAPI.Entities;

namespace BarcodeProductAPI.Data
{
    public interface IProductRepository
    {
        Task<Product> GetByBarcodeAsync(string barcode);
        Task AddProductAsync(Product product);
        Task UpdateProductAsync(Product product);
    }
}
