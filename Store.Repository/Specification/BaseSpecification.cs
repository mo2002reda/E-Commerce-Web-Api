using System.Linq.Expressions;

namespace Store.Repository.Specification
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;

        }

        public Expression<Func<T, bool>> Criteria { get; }

        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();

        public Expression<Func<T, object>> OrderByAsec { get; private set; }

        public Expression<Func<T, object>> OrderByDesc { get; private set; }

        public int Take { get; private set; }

        public int Skip { get; private set; }

        public bool IsPagination { get; private set; }



        #region function to can full the list of include by it
        protected void AddInclude(Expression<Func<T, object>> include)
       => Includes.Add(include);
        #endregion


        #region function to set above functions(OrderByAsec , OrderByDesc)
        protected void AddOrderByAsec(Expression<Func<T, object>> OrderBY)//take expression as input  
            => OrderByAsec = OrderBY;//set OrderByDesc
        protected void AddOrderByDesc(Expression<Func<T, object>> OrderBY)
            => OrderByDesc = OrderBY;
        #endregion

        public void ApplyPagination(int skip, int take)
        {
            Skip = skip;
            Take = take;
            IsPagination = true;
        }


    }

}
