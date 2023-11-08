using AutoMapper;
using Catalog.Application.Responses;
using Catalog.Core.Domain;

namespace Catalog.Application.Mappers
{
    public class ProductTypeMappingProfile : Profile
    {
        public ProductTypeMappingProfile()
        {
            CreateMap<ProductType, TypeResponse>().ReverseMap();
        }
    }
}
