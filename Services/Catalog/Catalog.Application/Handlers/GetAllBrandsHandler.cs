using Catalog.Application.Mappers;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers
{
    public class GetAllBrandsHandler : IRequestHandler<GetAllBrandsQuery, IList<BrandResponse>>
    {
        private readonly IBrandRepository _repository;

        public GetAllBrandsHandler(IBrandRepository repository)
        {
            _repository = repository;
        }

        public async Task<IList<BrandResponse>> Handle(GetAllBrandsQuery request, CancellationToken cancellationToken)
        {
            var list = await _repository.GetAllBrands();
            return ProductMapper.Mapper.Map<IList<BrandResponse>>(list);
        }
    }
}
