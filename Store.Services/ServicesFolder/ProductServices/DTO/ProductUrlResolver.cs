using AutoMapper;
using Microsoft.Extensions.Configuration;
using Store.Data.Entities;

namespace Store.Services.ServicesFolder.ProductServices.DTO
{
    public class ProductUrlResolver : IValueResolver<Product, ProductDetailsDTO, string>
    {
        private readonly IConfiguration _configurations;

        public ProductUrlResolver(IConfiguration configuration)
        {
            _configurations = configuration;
        }

        public string Resolve(Product source, ProductDetailsDTO destination, string destMember, ResolutionContext context)
        {//check if the pictur is exist or null
            if (!string.IsNullOrEmpty(source.PictureUrl))
                return $"{_configurations["BaseUrl"]}{source.PictureUrl}";

            return null;
        }
    }
}
