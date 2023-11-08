using Catalog.Application.Mappers;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers
{
    public class GetProductByNameHandler : IRequestHandler<GetProductByNameQuery, IList<ProductResponse>>
    {
        private readonly IProductRepository _repository;

        public GetProductByNameHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<IList<ProductResponse>> Handle(GetProductByNameQuery request, CancellationToken cancellationToken)
        {
            var list = await _repository.GetByName(request.Name);
            return ProductMapper.Mapper.Map< IList<ProductResponse>>(list);
        }
    }
}
