using Store.Services.HandleResponse;
using System.Net;
using System.Text.Json;

namespace Store.Api.Middlewares
{
    public class ExceptionMiddleWare
    {
        private readonly RequestDelegate _next;
        private readonly IHostEnvironment _environment;
        private readonly ILogger<ExceptionMiddleWare> _logger;

        public ExceptionMiddleWare(RequestDelegate next //this is the Request
            , IHostEnvironment environment
            //carry the environmentType (Production - envionment )if i'm in environment this will appear Details ,if Production this will not appear any Details of Exception
            , ILogger<ExceptionMiddleWare> logger
            )
        {
            _next = next; //the request
            _environment = environment;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, ex.Message);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                var response = _environment.IsDevelopment() ?
                    new CustomeException((int)HttpStatusCode.InternalServerError, ex.Message, ex.StackTrace)
                     : new CustomeException((int)HttpStatusCode.InternalServerError);

                var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

                var json = JsonSerializer.Serialize(response, options);

                await context.Response.WriteAsync(json);
                //then goto program file to Register my middle ware
            }
        }

    }
}
