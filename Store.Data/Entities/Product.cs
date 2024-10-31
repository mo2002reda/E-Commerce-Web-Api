using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.Entities
{
    public class Product : BaseEntity<int>
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public ProductBrand Brand { get; set; }//navigational prop <1 - 1>
        public int BrandId { get; set; }//FK ==>Brand
        public ProductType Type { get; set; }
        public int TypeId { get; set; }//FK==> ProductType <1 - 1>


    }
}
