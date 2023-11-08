using Catalog.Core.Common;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.Core.Domain
{
    public class Product : AggregateRoot
    {
        public Product(
            string id, 
            string name, 
            string summary, 
            string description, 
            string imageFile, 
            ProductBrand brand, 
            ProductType type, 
            decimal price)
        {
            Id = id;
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
        public ProductBrand Brand { get; protected set; }
        public ProductType Type { get; protected set; }

        [BsonRepresentation(BsonType.Decimal128)]
        public decimal Price { get; protected set; }
    }
}
