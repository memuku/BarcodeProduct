using BarcodeProductAPI.Entities;
using MongoDB.Driver;
using YourProject.Data;

namespace BarcodeProductAPI.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly MongoDbContext _context;

        public ProductRepository(MongoDbContext context)
        {
            _context = context;
        }

        public async Task<Product> GetByBarcodeAsync(string barcode)
        {
            return await _context.Products.Find(p => p.Barcode == barcode).FirstOrDefaultAsync();
        }

        public async Task AddProductAsync(Product product)
        {
            await _context.Products.InsertOneAsync(product);
        }

        public async Task UpdateProductAsync(Product product)
        {
            var filter = Builders<Product>.Filter.Eq(p => p.Id, product.Id);
            await _context.Products.ReplaceOneAsync(filter, product);
        }
    }
}
