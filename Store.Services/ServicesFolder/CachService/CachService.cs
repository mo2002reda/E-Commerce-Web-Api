using StackExchange.Redis;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Store.Services.ServicesFolder.CachService
{
    public class CachService : ICachService
    {
        private readonly IDatabase _database;
        public CachService(IConnectionMultiplexer redis)
        {//IConnectionMultiplexer = DbContext but IConnectionMultiplexer deal with memory
            _database = redis.GetDatabase();
        }

        public async Task<string> GetcacheResponseAsync(string key)
        {
            var CacheResponse = await _database.StringGetAsync(key);
            //do type of Key string because StringGetAsync(key)take Redis type
            if (CacheResponse.IsNullOrEmpty)//check if the value of the key is null or not
            { return null; }
            return CacheResponse.ToString();
        }

        public async Task SetCacheResponseAsync(string key, object response, TimeSpan TimeTolive)
        {
            //check if response is null or not
            if (response is null)
                return;
            var Options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            //will serialize the object because the response may be list of object(products) and the response(redis) should be string
            var SerializedResponse = JsonSerializer.Serialize(response, Options);
            //finally set the key and response and the timelive in memory
            await _database.StringSetAsync(key, SerializedResponse, TimeTolive);
        }
    }
}
