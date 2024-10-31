using AutoMapper;
using Store.Repository.BasketRepository.Interfaces;
using Store.Repository.BasketRepository.Model;
using Store.Services.ServicesFolder.BasketService.DTOS;

namespace Store.Services.ServicesFolder.BasketService
{
    public class BasketService : IBasketService
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;

        public BasketService(IBasketRepository basketRepository, IMapper mapper)
        {
            _basketRepository = basketRepository;
            _mapper = mapper;
        }

        public async Task<bool> DeleteBasketAsync(string basketId)
            => await _basketRepository.DeleteBasketAsync(basketId);


        public async Task<CustomerBasketDTO> GetBasketAsync(string basketId)
        {
            var basket = await _basketRepository.GetBasketAsync(basketId);

            if (basket is null)
                return new CustomerBasketDTO();
            //if there is basket it will mapped it to return
            var mappedBasket = _mapper.Map<CustomerBasketDTO>(basket);

            return mappedBasket;
        }

        public async Task<CustomerBasketDTO> UpdateBasketAsync(CustomerBasketDTO basket)
        {   //map from CustomerBasketDTO(input) to (CustomerBasket)
            var CustomerBasketitem = _mapper.Map<CustomerBasket>(basket);
            var UpdatedBasket = await _basketRepository.UpdateBasketAsync(CustomerBasketitem);//updated Successfully
            //map from CustomerBasket(Current input) to CustomerBasketDTO (OutPut)
            var mappedCustomerBasket = _mapper.Map<CustomerBasketDTO>(UpdatedBasket);
            return mappedCustomerBasket;
        }
    }
}
