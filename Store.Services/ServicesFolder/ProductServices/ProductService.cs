using AutoMapper;
using Store.Data.Entities;
using Store.Repository.Interfaces;
using Store.Repository.Specification.ProductsSpecification;
using Store.Services.Helper;
using Store.Services.ServicesFolder.ProductServices.DTO;

namespace Store.Services.ServicesFolder.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IUniteOfWork _uniteOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUniteOfWork uniteOfWork, IMapper mapper)
        {
            _uniteOfWork = uniteOfWork;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<BrandTypeDetailsDto>> GetAllBrandsAsync()
        {

            //1)catch all brands
            var brands = await _uniteOfWork.Repository<ProductBrand, int>().GetAllAsync();

            //2)mapped brands
            var mappedProduct = _mapper.Map<IReadOnlyList<BrandTypeDetailsDto>>(brands);
            //3)return the requirements
            return mappedProduct;
        }


        public async Task<IReadOnlyList<BrandTypeDetailsDto>> GetAllTypesAsync()
        {

            var types = await _uniteOfWork.Repository<ProductType, int>().GetAllAsync();

            var mapped = _mapper.Map<IReadOnlyList<BrandTypeDetailsDto>>(types);
            return mapped;

        }

        public async Task<ProductDetailsDTO> GetProductbyIdAsync(int? id)
        {
            if (id is null)
                throw new Exception("ID is null");
            #region Without using Specification (BrandId,TypeId) will be null
            //var Product = await _uniteOfWork.Repository<Product, int>().GetbyIdAsunc(id.Value); 
            #endregion

            var specs = new ProductsWithSpecifications(id);//initilize Object to can use its constructor


            var product = await _uniteOfWork.Repository<Product, int>().GetSpecificationbyIdAsunc(specs);
            if (product is null)
                throw new Exception("Product not Found");
            var mappedProduct = _mapper.Map<ProductDetailsDTO>(product);
            return mappedProduct;
        }

        #region without using Spacification => not send Parameters
        //public async Task<IReadOnlyList<ProductDetailsDTO>> GetAllProductsAsync() 
        #endregion
        public async Task<PaginatedResultDTO<ProductDetailsDTO>> GetAllProductsAsync(ProductSpecification input)
        {
            #region Get All Products without using Spacification (BrandId,TypeId)will be null
            //var Products = _uniteOfWork.Repository<Product, int>().GetAllAsync(); 
            #endregion
            var specs = new ProductsWithSpecifications(input);

            var Products = await _uniteOfWork.Repository<Product, int>().GetAllSpecificationAsync(specs);

            var CountSpecs = new ProductsWithFilterandCountSepcification(input);
            var count = await _uniteOfWork.Repository<Product, int>().CountWithSpecifivationAsync(CountSpecs);


            var mappedProducts = _mapper.Map<IReadOnlyList<ProductDetailsDTO>>(Products);
            //return mappedProducts;
            return new PaginatedResultDTO<ProductDetailsDTO>(input.PageIndex, input.PageSize, count, mappedProducts);
        }
    }
}
