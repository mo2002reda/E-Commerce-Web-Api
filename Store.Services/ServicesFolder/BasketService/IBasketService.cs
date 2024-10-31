using Store.Repository.BasketRepository.Model;
using Store.Services.ServicesFolder.BasketService.DTOS;

namespace Store.Services.ServicesFolder.BasketService
{
    public interface IBasketService
    {
        Task<CustomerBasketDTO> GetBasketAsync(string basketId);
        Task<CustomerBasketDTO> UpdateBasketAsync(CustomerBasketDTO basket);
        Task<bool> DeleteBasketAsync(string basketId);
    }
}
