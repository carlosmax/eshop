using Catalog.Core.Common;

namespace Catalog.Core.Domain
{
    public class ProductType : Entity
    {
        public ProductType(string id, string name)
        {
            Id = id;
            Name = name;
        }

        public string Name { get; set; }
    }
}
