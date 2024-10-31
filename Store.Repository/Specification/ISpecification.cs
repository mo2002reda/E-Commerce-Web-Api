using System.Linq.Expressions;

namespace Store.Repository.Specification
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Criteria { get; }

        List<Expression<Func<T, object>>> Includes { get; }//function to do Include 

        Expression<Func<T, object>> OrderByAsec { get; }//function to order by ascending return Expression
        Expression<Func<T, object>> OrderByDesc { get; }
        int Take { get; }
        int Skip { get; }
        bool IsPagination { get; }



    }
}
