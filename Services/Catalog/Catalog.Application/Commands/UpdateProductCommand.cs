using Catalog.Application.Responses;
using MediatR;

namespace Catalog.Application.Commands
{
    public class UpdateProductCommand : IRequest<bool>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string ImageFile { get; set; }
        public BrandResponse Brand { get; set; }
        public TypeResponse Type { get; set; }
        public decimal Price { get; set; }
    }
}
