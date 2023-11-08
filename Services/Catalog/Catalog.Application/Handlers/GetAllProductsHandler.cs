using Catalog.Application.Mappers;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, IList<ProductResponse>>
    {
        private readonly IProductRepository _repository;

        public GetAllProductsHandler(IProductRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<IList<ProductResponse>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var list = await _repository.GetAll();
            return ProductMapper.Mapper.Map<IList<ProductResponse>>(list);
        }
    }
}
