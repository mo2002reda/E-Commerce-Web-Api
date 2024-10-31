using Store.Data.DataContext;
using Store.Data.Entities;
using Store.Repository.Interfaces;
using System.Collections;

namespace Store.Repository.Repository
{
    public class UniteOfWork : IUniteOfWork
    {
        private readonly StoreDbContext _context;
        private Hashtable _repository;

        //2)declare an instance from Hash table to can use it in function
        //private Hashtable _repository;

        public UniteOfWork(StoreDbContext context)
        {
            _context = context;

        }

        public async Task<int> CompleteAsync() => await _context.SaveChangesAsync();

        //using hash table in this function to check if there is exist Repository in hash table or not
        //hash table formed from Key=EntityName & value= instace of the entity
        //this hashTable will carry all repositories which made and which will made
        //if it has the repository : we will work on it 
        //if it hasn't the repository : it will create another Repository
        public IGenericRepository<TEntity, TKey> Repository<TEntity, TKey>() where TEntity : BaseEntity<TKey>
        {   //1)check at Hash Table if Exist Or Not
            if (_repository is null)
            {     //this mean that we don't have any Repository in hash table so we will create one by declare an object from it
                _repository = new Hashtable();
            }


            //2)catch the Key (entity name)
            var entityKey = typeof(TEntity).Name;
            //Ex: When Calling ==> Repository<Product,int> so entitykey will carry :product

            //3)check at the entity if not exist ==> create one 
            if (!_repository.ContainsKey(entityKey))
            {

                //if it hasn't this entity it will create one 
                var repositoryType = typeof(GenericRepository<,>);//create an entity (Key)

                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity), typeof(TKey)), _context);
                //this will carry the instance of Entity (Value) and context which deal with database
                //4)Add the Key & Value To HashTable
                _repository.Add(entityKey, repositoryInstance);

            }
            //5)return repositories which made

            return (IGenericRepository<TEntity, TKey>)_repository[entityKey];
            //The type of function is Generic and it return HashTable so we will do exeplict casting to type of function
        }
    }
}
