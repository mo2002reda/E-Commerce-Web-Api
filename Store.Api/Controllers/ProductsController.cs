using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.Api.Helper;
using Store.Repository.Specification.ProductsSpecification;
using Store.Services.Helper;
using Store.Services.ServicesFolder.ProductServices;
using Store.Services.ServicesFolder.ProductServices.DTO;

namespace Store.Api.Controllers
{
    [Authorize]
    public class ProductsController : BaseController
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]//[HttpGet("brands")] : can use it instead of using /[action] with api/[controller]
        [Caching(30)]
        public async Task<ActionResult<IReadOnlyList<BrandTypeDetailsDto>>> GetAllBrands()
            => Ok(await _service.GetAllBrandsAsync());

        [HttpGet]
        [Caching(90)]//90 =>Second 
                     //can't use [FromBody] with Get Action
        #region WithOut Using Pagination
        //public async Task<ActionResult<IReadOnlyList<ProductDetailsDTO>>> GetAllProducts([FromQuery] ProductSpecification input) 
        #endregion
        public async Task<ActionResult<PaginatedResultDTO<ProductDetailsDTO>>> GetAllProducts([FromQuery] ProductSpecification input)
            => Ok(await _service.GetAllProductsAsync(input));

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<BrandTypeDetailsDto>>> GetAllTypes()
            => Ok(await _service.GetAllTypesAsync());

        [HttpGet]
        public async Task<ActionResult<ProductDetailsDTO>> GetProductById(int? id)
             => Ok(await _service.GetProductbyIdAsync(id));

    }
}
