using Store.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository.Specification.ProductsSpecification
{
    public class ProductsWithFilterandCountSepcification : BaseSpecification<Product>
    {
        public ProductsWithFilterandCountSepcification(ProductSpecification specs) :
            base(product => !specs.BrandId.HasValue || product.BrandId == specs.BrandId.Value)
        {
        }
    }
}
