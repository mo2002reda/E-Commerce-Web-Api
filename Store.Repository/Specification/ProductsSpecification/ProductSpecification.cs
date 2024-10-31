using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository.Specification.ProductsSpecification
{
    public class ProductSpecification
    {//make properity nullable to consider if user doesn't send it ,the response will be all brands
        public int? BrandId { get; set; }
        public int? TypeId { get; set; }
        public string? Sort { get; set; }

        //if user enter BrandId Only: the response will be product match that BrandId
        //if user enter TypeId Only: the response will be product match that TypeId
        //if user not enter BrandId & TypeId: the response will be All products
        public int PageIndex { get; set; } = 1;      //Current Page by default= page number 1
        private int _PageSize = 6;                   //Number of Products per Every page  by default= 6 products 
        private const int MAXPAGESIZE = 50;          //Maxmum Number Of Products per page = 50 product 
        public int PageSize
        {
            get { return _PageSize = 6; }
            set => _PageSize = (value > MAXPAGESIZE) ? 50 : value;
        }



    }

}
