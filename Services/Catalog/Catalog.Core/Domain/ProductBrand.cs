using Catalog.Core.Common;

namespace Catalog.Core.Domain
{
    public class ProductBrand : Entity
    {
        public ProductBrand(string id, string name)
        {
            Id = id;
            Name = name;
        }

        public string Name { get; protected set; }
    }
}
