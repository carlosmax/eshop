﻿using AutoMapper;
using Catalog.Application.Responses;
using Catalog.Core.Domain;

namespace Catalog.Application.Mappers
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<ProductBrand, BrandResponse>().ReverseMap();
            CreateMap<ProductType, TypeResponse>().ReverseMap();
            CreateMap<Product, ProductResponse>().ReverseMap();
        }
    }
}
