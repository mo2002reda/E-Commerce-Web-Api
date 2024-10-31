using Store.Repository.Specification.ProductsSpecification;
using Store.Services.Helper;
using Store.Services.ServicesFolder.ProductServices.DTO;

namespace Store.Services.ServicesFolder.ProductServices
{
    public interface IProductService
    {
        Task<ProductDetailsDTO> GetProductbyIdAsync(int? id);//to get product Details by id
        #region WithOut using Specification =>the function not take any parameters
        //Task<IReadOnlyList<ProductDetailsDTO>> GetAllProductsAsync();//to get list product Details 
        #endregion
        #region Using Specification but withOut using Pagination
        // Task<IReadOnlyList<ProductDetailsDTO>> GetAllProductsAsync(ProductSpecification input); 
        #endregion
        Task<PaginatedResultDTO<ProductDetailsDTO>> GetAllProductsAsync(ProductSpecification input);
        Task<IReadOnlyList<BrandTypeDetailsDto>> GetAllBrandsAsync();
        Task<IReadOnlyList<BrandTypeDetailsDto>> GetAllTypesAsync();
    }
}
