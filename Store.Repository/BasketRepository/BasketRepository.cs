using StackExchange.Redis;
using Store.Repository.BasketRepository.Interfaces;
using Store.Repository.BasketRepository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Store.Repository.BasketRepository
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDatabase _database;
        //used IConnectionMultiplexer to can use redis 
        public BasketRepository(IConnectionMultiplexer redis)
        {
            _database = redis.GetDatabase();
        }

        public async Task<bool> DeleteBasketAsync(string basketId)
            => await _database.KeyDeleteAsync(basketId);


        public async Task<CustomerBasket> GetBasketAsync(string basketId)
        {
            var data = await _database.StringGetAsync(basketId);
            if (data.IsNullOrEmpty)
                return null;
            return JsonSerializer.Deserialize<CustomerBasket>(data);//turn from data (string) to CustomerBasket
        }

        public async Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket)
        {
            var IsCreated = await _database.StringSetAsync(basket.Id, JsonSerializer.Serialize(basket), TimeSpan.FromDays(30));

            if (!IsCreated)//meaning that the redis not created because there is anotherone or not set redis with this key(id)
                return null;
            return await GetBasketAsync(basket.Id);
        }
    }
}
