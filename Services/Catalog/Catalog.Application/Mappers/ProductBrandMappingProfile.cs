using AutoMapper;
using Catalog.Application.Responses;
using Catalog.Core.Domain;

namespace Catalog.Application.Mappers
{
    public class ProductBrandMappingProfile : Profile
    {
        public ProductBrandMappingProfile()
        {
            CreateMap<ProductBrand, BrandResponse>().ReverseMap();
        }
    }
}
