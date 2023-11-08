using AutoMapper;
using Catalog.Application.Responses;
using Catalog.Core.Domain;

namespace Catalog.Application.Mappers
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<Product, ProductResponse>().ReverseMap();
        }
    }
}
