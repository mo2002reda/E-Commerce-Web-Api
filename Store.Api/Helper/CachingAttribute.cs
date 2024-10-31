using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Store.Services.ServicesFolder.CachService;
using System.CodeDom.Compiler;
using System.Text;

namespace Store.Api.Helper
{
    public class CachingAttribute : Attribute, IAsyncActionFilter
    {
        private readonly int _timeToLiveInSecond;

        public CachingAttribute(int TimeToLiveInSecond)
        {
            _timeToLiveInSecond = TimeToLiveInSecond;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {   //inject CashService here instead of constructor because if we inject it in cons we should send parameters in controller ex:[Caching (10)] 
            var _cachService = context.HttpContext.RequestServices.GetRequiredService<ICachService>();

            var CachKey = GeneratedCachKeyFromRequest(context.HttpContext.Request);//to get key from Request

            var CachedResponse = await _cachService.GetcacheResponseAsync(CachKey);

            if (!string.IsNullOrEmpty(CachedResponse))
            {
                var contentResult = new ContentResult();
                {
                    contentResult.Content = CachedResponse;
                    contentResult.ContentType = "application/json";
                    contentResult.StatusCode = 200;//Ok
                };
                context.Result = contentResult;
                return;
            }
            var ExecutedContext = await next();//will move to execute action in controller 
            if (ExecutedContext.Result is OkObjectResult response)//if ok Store it in response variable 
                await _cachService.SetCacheResponseAsync(CachKey, response, TimeSpan.FromSeconds(_timeToLiveInSecond));
            //is OkObjectResult => is Casting


        }
        private string GeneratedCachKeyFromRequest(HttpRequest request)
        {
            StringBuilder CachKey = new StringBuilder();
            CachKey.Append($"{request.Path}");
            foreach (var (key, value) in request.Query.OrderBy(x => x.Key))
            { CachKey.Append($"|{key}-{value}"); }

            return CachKey.ToString();
        }
    }
}
