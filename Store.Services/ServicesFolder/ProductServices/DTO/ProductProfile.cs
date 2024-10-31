using AutoMapper;
using Store.Data.Entities;
using Store.Services.Helper;

namespace Store.Services.ServicesFolder.ProductServices.DTO
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDetailsDTO>()
                .ForMember(brands => brands.BrandName, options => options.MapFrom(src => src.Brand.Name))
                .ForMember(type => type.TypeName, options => options.MapFrom(src => src.Type.Name))
                .ForMember(type => type.PictureUrl, options => options.MapFrom<ProductUrlResolver>());


            CreateMap<ProductType, BrandTypeDetailsDto>();
            CreateMap<ProductBrand, BrandTypeDetailsDto>();
        }

    }
}
