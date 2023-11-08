using Catalog.Application.Commands;
using Catalog.Application.Mappers;
using Catalog.Application.Responses;
using Catalog.Core.Domain;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, ProductResponse>
    {
        private readonly IProductRepository _repository;

        public CreateProductHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<ProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = Product.Create(
                request.Name, 
                request.Summary, 
                request.Description, 
                request.ImageFile, 
                request.Brand.Id, 
                request.Brand.Name, 
                request.Type.Id, 
                request.Type.Name, 
                request.Price);

            var createdProduct = await _repository.Create(product);

            return ProductMapper.Mapper.Map<ProductResponse>(createdProduct);
        }
    }
}
