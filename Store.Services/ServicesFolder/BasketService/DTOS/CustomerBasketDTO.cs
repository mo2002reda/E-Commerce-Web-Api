using Store.Repository.BasketRepository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.ServicesFolder.BasketService.DTOS
{
    public class CustomerBasketDTO
    {
        public string Id { get; set; }//the Key 
        public int? DleverymethodId { get; set; }
        public decimal shippingPrice { get; set; }
        public List<BasketItemDTO> BasketItems { get; set; } = new List<BasketItemDTO>();
    }
}
