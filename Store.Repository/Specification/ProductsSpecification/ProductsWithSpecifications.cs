using Store.Data.Entities;
using System.Linq.Expressions;

namespace Store.Repository.Specification.ProductsSpecification
{//this class has all includes and Criterias which belong to Product Class
    public class ProductsWithSpecifications : BaseSpecification<Product>
    {//inject ProductSpecification in the instructor to can deal with the object which exist there
     //do chaining because the class inherit from another Class and write expressions on it
     //Criteries to filter the products  

        #region Get All Products Senerio
        public ProductsWithSpecifications(ProductSpecification specs) :
            base(product => !specs.BrandId.HasValue || product.BrandId == specs.BrandId.Value &&
                            !specs.TypeId.HasValue || product.TypeId == specs.TypeId.Value)

        {
            #region explain of Base(Expressions)
            //!specs.BrandId.HasValue ==> because the Type of brandId is nullable this mean this will show          all Brands 
            //product.BrandId== specs.BrandId.Value ==> if the brandId has input from user

            #endregion
            AddInclude(x => x.Brand);
            AddInclude(x => x.Type);
            AddOrderByAsec(x => x.Name); //default sorting

            if (!string.IsNullOrEmpty(specs.Sort))//if the inputText of Sort not null
            {
                switch (specs.Sort)
                {
                    case "priceAsec":
                        AddOrderByAsec(x => x.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDesc(x => x.Price);
                        break;
                    default:
                        AddOrderByAsec(x => x.Name);
                        break;
                }
            }
            ApplyPagination(specs.PageSize * (specs.PageIndex - 1), specs.PageSize);
            //pageSize *PageIndex-1 =>Skip
            //Take =>PageSize




        }
        #endregion
        #region Get By Product Id Senerio
        //the Expression Here will filter with Id of Product
        public ProductsWithSpecifications(int? id) : base(product => product.id == id)
        {
            AddInclude(x => x.Brand);
            AddInclude(x => x.Type);
        }
        #endregion
    }
}
