using Catalog.Core.Domain;
using MongoDB.Driver;
using System.Text.Json;

namespace Catalog.Infrastructure.Data.Seed
{
    public static class TypeSeed
    {
        public static void SeedData(IMongoCollection<ProductType> collection)
        {
            var checkBrands = collection.Find(i => true).Any();

            if (!checkBrands)
            {
                var path = Path.Combine("Data", "SeedData", "types.json");
                var typesData = File.ReadAllText(path);
                var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);

                if (types != null)
                {
                    foreach (var type in types)
                    {
                        collection.InsertOneAsync(type);
                    }
                }
            }
        }
    }
}
