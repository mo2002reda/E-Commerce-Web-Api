using Store.Data.Entities;
using Store.Repository.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository.Interfaces
{
    public interface IGenericRepository<TEntity, Tkey> where TEntity : BaseEntity<Tkey>
    {   //TEntity: the type of the entity which used (name of entity)
        //TKey : the type of the Key of the entity which used
        Task<TEntity> GetbyIdAsunc(Tkey? id);
        Task<IReadOnlyList<TEntity>> GetAllAsync();//IReadOnlyList : used to get only list of item (can't set any items)
        Task<TEntity> GetSpecificationbyIdAsunc(ISpecification<TEntity> specs);
        Task<IReadOnlyList<TEntity>> GetAllSpecificationAsync(ISpecification<TEntity> specs);
        Task<int> CountWithSpecifivationAsync(ISpecification<TEntity> specs);
        Task AddAsync(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);

    }
}
