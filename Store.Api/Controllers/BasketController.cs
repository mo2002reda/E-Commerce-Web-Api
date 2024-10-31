using Microsoft.AspNetCore.Mvc;
using Store.Services.ServicesFolder.BasketService;
using Store.Services.ServicesFolder.BasketService.DTOS;

namespace Store.Api.Controllers
{
    public class BasketController : BaseController
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerBasketDTO>> GetbyId(string id)
          => Ok(await _basketService.GetBasketAsync(id));


        [HttpPost]
        public async Task<ActionResult<CustomerBasketDTO>> UpdateBasket(CustomerBasketDTO basket)
            => Ok(await _basketService.UpdateBasketAsync(basket));

        [HttpDelete]
        public async Task<ActionResult> DeleteBasket(String basketID)
            => Ok(await _basketService.DeleteBasketAsync(basketID));


    }
}
