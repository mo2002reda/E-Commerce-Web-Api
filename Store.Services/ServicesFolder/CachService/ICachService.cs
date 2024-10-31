namespace Store.Services.ServicesFolder.CachService
{
    public interface ICachService
    {   //function to set Cache (Basket)
        //key :will carry the instance of the object in cach
        //response : will carry the objects(value) that i put(load )it
        //TimeToLive : the time of caching the object in memory 
        Task SetCacheResponseAsync(string key, object response, TimeSpan TimeTolive);
        Task<string> GetcacheResponseAsync(string key);//take the instance to get value   
    }
}
