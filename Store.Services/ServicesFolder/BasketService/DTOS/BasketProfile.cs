using AutoMapper;
using Store.Repository.BasketRepository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.ServicesFolder.BasketService.DTOS
{
    public class BasketProfile : Profile
    {
        protected BasketProfile()
        {
            CreateMap<BasketItemDTO, BasketItem>().ReverseMap();
            CreateMap<CustomerBasket, CustomerBasketDTO>().ReverseMap();

        }
    }
}
