using Store.Data.Entities;

namespace Store.Repository.Interfaces
{
    //this interface carry all interfaces which we used
    public interface IUniteOfWork
    {
        // IGenericRepository<TEntity, TKey> Repository<TEntity, TKey>() where TEntity : BaseEntity<TKey>;
        //made function which data type is generic and named Repository and take generic type
        IGenericRepository<TEntity, TKey> Repository<TEntity, TKey>() where TEntity : BaseEntity<TKey>;
        Task<int> CompleteAsync();
    }
}
