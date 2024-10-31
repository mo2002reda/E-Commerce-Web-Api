using Microsoft.EntityFrameworkCore;
using Store.Data.DataContext;
using Store.Data.Entities;
using Store.Repository.Interfaces;
using Store.Repository.Specification;

namespace Store.Repository.Repository
{
    public class GenericRepository<TEntity, Tkey> : IGenericRepository<TEntity, Tkey> where TEntity : BaseEntity<Tkey>
    {
        private readonly StoreDbContext _context;

        public GenericRepository(StoreDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(TEntity entity)
            => await _context.Set<TEntity>().AddAsync(entity);


        public void Delete(TEntity entity)
            => _context.Remove(entity);


        public async Task<IReadOnlyList<TEntity>> GetAllAsync()
            => await _context.Set<TEntity>().ToListAsync();

        public async Task<IReadOnlyList<TEntity>> GetAllSpecificationAsync(ISpecification<TEntity> specs)
        #region Old Version
        //=> await SpacificationEvaluator<TEntity, Tkey>.GetQuery(_context.Set<TEntity>(), specs).ToListAsync(); 
        #endregion
            => await ApplySpacification(specs).ToListAsync();


        public async Task<TEntity> GetSpecificationbyIdAsunc(ISpecification<TEntity> specs)
        #region old Version
            //  =>await SpacificationEvaluator<TEntity,Tkey>.GetQuery(_context.Set<TEntity>(),
            // specs).FirstOrDefaultAsync(); 
        #endregion
            => await ApplySpacification(specs).FirstOrDefaultAsync();

        public async Task<int> CountWithSpecifivationAsync(ISpecification<TEntity> specs)
            => await ApplySpacification(specs).CountAsync();

        public async Task<TEntity> GetbyIdAsunc(Tkey? id)
            => await _context.Set<TEntity>().FindAsync(id);


        public void Update(TEntity entity)
            => _context.Set<TEntity>().Update(entity);


        #region instead of dublicate this code in (GetAllSpecificationAsync,GetSpecificationbyIdAsunc)
        //GetQuery function return IQueryable<TEntity> so the return type of function will be IQueryable<TEntity> 
        private IQueryable<TEntity> ApplySpacification(ISpecification<TEntity> specs)
            => SpacificationEvaluator<TEntity, Tkey>.GetQuery(_context.Set<TEntity>(),
                 specs);


        #endregion

    }
}
