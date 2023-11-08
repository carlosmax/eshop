using Catalog.Core.Common;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.Core.Domain
{
    public class Product : AggregateRoot
    {
        public Product(
            string name, 
            string summary, 
            string description, 
            string imageFile, 
            ProductBrand brand, 
            ProductType type, 
            decimal price)
        {
            Name = name;
            Summary = summary;
            Description = description;
            ImageFile = imageFile;
            Brand = brand;
            Type = type;
            Price = price;
        }

        public string Name { get; protected set; }
        public string Summary { get; protected set; }
        public string Description { get; protected set; }
        public string ImageFile { get; protected set; }        

        [BsonRepresentation(BsonType.Decimal128)]
        public decimal Price { get; protected set; }
        public ProductBrand Brand { get; protected set; }
        public ProductType Type { get; protected set; }

        public void Update(string name, string summary, string description, string imageFile, string brandId, string brandName, string typeId, string typeName, decimal price)
        {            
            Name = name;
            Summary = summary;
            Description = description;
            ImageFile = imageFile;
            Price = price;

            var brand = new ProductBrand(brandId, brandName);
            var type = new ProductType(typeId, typeName);

            Brand = brand;
            Type = type;             
        }

        public static Product Create(string name, string summary, string description, string imageFile, string brandId, string brandName, string typeId, string typeName, decimal price)
        {
            var brand = new ProductBrand(brandId, brandName);
            var type = new ProductType(typeId, typeName);

            return new Product(name, summary, description, imageFile, brand, type, price);
        }
    }
}
