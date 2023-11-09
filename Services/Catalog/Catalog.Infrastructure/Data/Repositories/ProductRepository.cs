using Catalog.Core.Domain;
using Catalog.Core.Repositories;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ICatalogContext _context;

        public ProductRepository(ICatalogContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _context.Products.Find(i => true).ToListAsync();
        }

        public async Task<IEnumerable<ProductBrand>> GetAllBrands()
        {
            return await _context.Brands.Find(i => true).ToListAsync();
        }

        public async Task<IEnumerable<ProductType>> GetAllTypes()
        {
            return await _context.Types.Find(i => true).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetByName(string name)
        {
            return await _context.Products.Find(i => i.Name == name).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetByBrand(string brand)
        {
            var filter = Builders<Product>.Filter.Eq(i => i.Brand.Name, brand);
            return await _context.Products.Find(filter).ToListAsync();
        }

        public async Task<Product> GetById(string id)
        {
            return await _context.Products.Find(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Product> Create(Product product)
        {
            await _context.Products.InsertOneAsync(product);
            return product;
        }

        public async Task<bool> Update(Product product)
        {
            var result = await _context.Products.ReplaceOneAsync(i => i.Id == product.Id, product);
            return result.IsAcknowledged && result.ModifiedCount > 0;
        }

        public async Task<bool> Delete(string id)
        {
            var filter = Builders<Product>.Filter.Eq(i => i.Id, id);
            var result = await _context.Products.DeleteOneAsync(filter);
            return result.IsAcknowledged && result.DeletedCount > 0;
        }
    }
}
