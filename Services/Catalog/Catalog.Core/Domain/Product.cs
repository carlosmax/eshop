using Catalog.Core.Common;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.Core.Domain
{
    public class Product : AggregateRoot
    {
        public Product(string id, string name, string summary, string description, string imageFile, ProductBrand brands, ProductType types, decimal price)
        {
            Id = id;
            Name = name;
            Summary = summary;
            Description = description;
            ImageFile = imageFile;
            Brands = brands;
            Types = types;
            Price = price;
        }

        public string Name { get; protected set; }
        public string Summary { get; protected set; }
        public string Description { get; protected set; }
        public string ImageFile { get; protected set; }
        public ProductBrand Brands { get; protected set; }
        public ProductType Types { get; protected set; }

        [BsonRepresentation(BsonType.Decimal128)]
        public decimal Price { get; protected set; }
    }
}
