using Catalog.Application.Mappers;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers
{
    public class GetAllTypesHandler : IRequestHandler<GetAllTypesQuery, IList<TypeResponse>>
    {
        private readonly ITypeRepository _repository;

        public GetAllTypesHandler(ITypeRepository repository)
        {
            _repository = repository;
        }

        public async Task<IList<TypeResponse>> Handle(GetAllTypesQuery request, CancellationToken cancellationToken)
        {
            var list = await _repository.GetAllTypes();
            return ProductMapper.Mapper.Map<IList<TypeResponse>>(list);
        }
    }
}
