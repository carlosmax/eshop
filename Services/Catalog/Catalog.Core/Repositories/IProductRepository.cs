using Catalog.Core.Common;
using Catalog.Core.Domain;

namespace Catalog.Core.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetByName(string name);
        Task<IEnumerable<Product>> GetByBrand(string brand);
        Task<IEnumerable<ProductBrand>> GetAllBrands();
        Task<IEnumerable<ProductType>> GetAllTypes();
    }
}
