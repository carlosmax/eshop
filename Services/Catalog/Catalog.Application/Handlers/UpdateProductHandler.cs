using Catalog.Application.Commands;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, bool>
    {
        private readonly IProductRepository _repository;

        public UpdateProductHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetById(request.Id);

            product.Update(
                request.Name,
                request.Summary,
                request.Description,
                request.ImageFile,
                request.Brand.Id,
                request.Brand.Name,
                request.Type.Id,
                request.Type.Name,
                request.Price);

            return await _repository.Update(product);
        }
    }
}
