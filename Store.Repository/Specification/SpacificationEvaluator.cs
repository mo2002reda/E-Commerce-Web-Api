using Microsoft.EntityFrameworkCore;
using Store.Data.Entities;

namespace Store.Repository.Specification
{
    public class SpacificationEvaluator<TEntity, Tkey> where TEntity : BaseEntity<Tkey>
    {//have afunction to get Query //the name of entity + Specification : Expression , Inclueds
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> InputQuery, ISpecification<TEntity> specs)
        {
            var query = InputQuery;
            if (specs.Criteria is not null)
                query = query.Where(specs.Criteria);

            if (specs.OrderByDesc is not null)
                query = query.OrderByDescending(specs.OrderByDesc);

            if (specs.OrderByAsec is not null)
                query = query.OrderBy(specs.OrderByAsec);

            if (specs.IsPagination)
                query = query.Skip(specs.Skip).Take(specs.Take);

            query = specs.Includes.Aggregate(query, (current, IncludeExpression) => current.Include(IncludeExpression));//to Append Current Expression to old Expression

            return query;

        }
    }
}
