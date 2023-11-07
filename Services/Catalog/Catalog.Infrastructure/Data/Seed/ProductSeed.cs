using Catalog.Core.Domain;
using MongoDB.Driver;
using System.Text.Json;

namespace Catalog.Infrastructure.Data.Seed
{
    public static class ProductSeed
    {
        public static void SeedData(IMongoCollection<Product> collection)
        {
            var checkBrands = collection.Find(i => true).Any();

            if (!checkBrands)
            {
                var path = Path.Combine("Data", "SeedData", "products.json");
                var productsData = File.ReadAllText(path);
                var products = JsonSerializer.Deserialize<List<Product>>(productsData);

                if (products != null)
                {
                    foreach (var product in products)
                    {
                        collection.InsertOneAsync(product);
                    }
                }
            }
        }
    }
}
