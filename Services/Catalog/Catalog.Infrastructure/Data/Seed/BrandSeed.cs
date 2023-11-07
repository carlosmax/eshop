using Catalog.Core.Domain;
using MongoDB.Driver;
using System.Text.Json;

namespace Catalog.Infrastructure.Data.Seed
{
    public static class BrandSeed
    {
        public static void SeedData(IMongoCollection<ProductBrand> collection)
        {
            var checkBrands = collection.Find(i => true).Any();

            if (!checkBrands)
            {
                var path = Path.Combine("Data", "SeedData", "brands.json");
                var brandsData = File.ReadAllText(path);
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

                if (brands != null)
                {
                    foreach (var brand in brands)
                    {
                        collection.InsertOneAsync(brand);
                    }
                }
            }
        }
    }
}
