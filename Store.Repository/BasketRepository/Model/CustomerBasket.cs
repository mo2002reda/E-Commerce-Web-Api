using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository.BasketRepository.Model
{
    public class CustomerBasket
    {
        public string Id { get; set; }//the Key 
        public int? DleverymethodId { get; set; }
        public decimal shippingPrice { get; set; }
        public List<BasketItem> BasketItems { get; set; } = new List<BasketItem>();
    }
}
