using AutoMapper;

namespace Catalog.Application.Mappers
{
    public static class ProductMapper
    {
        private static readonly Lazy<IMapper> Lazy = new(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.ShouldMapProperty = p => (p?.GetMethod?.IsPublic ?? false) || (p?.GetMethod?.IsAssembly ?? false);
                cfg.AddProfile<ProductMappingProfile>();
            });

            return config.CreateMapper();
        });


        public static IMapper Mapper => Lazy.Value;
    }
}
