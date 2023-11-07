using Catalog.Core.Domain;
using Catalog.Infrastructure.Data.Seed;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Data
{
    public class CatalogContext : ICatalogContext
    {
        private readonly IMongoDatabase _database;

        public CatalogContext(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("CatalogDatabase");
            var databaseName = configuration.GetSection("DatabaseSettings:DatabaseName").Value;

            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);

            BrandSeed.SeedData(Brands);
            TypeSeed.SeedData(Types);
            ProductSeed.SeedData(Products);
        }

        public IMongoCollection<Product> Products
        {
            get
            {
                return _database.GetCollection<Product>("Products");
            }
        }

        public IMongoCollection<ProductBrand> Brands {
            get
            {
                return _database.GetCollection<ProductBrand>("Brands");
            }
        }

        public IMongoCollection<ProductType> Types {
            get
            {
                return _database.GetCollection<ProductType>("Types");
            }
        }
    }
}
