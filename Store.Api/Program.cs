using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using Store.Api.Extentions;
using Store.Api.Helper;
using Store.Api.Middlewares;
using Store.Data.DataContext;
using Store.Repository.BasketRepository;
using Store.Repository.BasketRepository.Interfaces;
using Store.Repository.Interfaces;
using Store.Repository.Repository;
using Store.Services.ServicesFolder.BasketService;
using Store.Services.ServicesFolder.BasketService.DTOS;
using Store.Services.ServicesFolder.CachService;
using Store.Services.ServicesFolder.ProductServices;
using Store.Services.ServicesFolder.ProductServices.DTO;
using Store.Services.ServicesFolder.Tokens;
using Store.Services.ServicesFolder.UseServices;

namespace Store.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<StoreDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddDbContext<StoreIdentityDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection"));
            });



            builder.Services.AddSingleton<IConnectionMultiplexer>(config =>
            {
                var Configuration = ConfigurationOptions.Parse(builder.Configuration.GetConnectionString("Redis"));
                return ConnectionMultiplexer.Connect(Configuration);
            });
            builder.Services.AddScoped<IUniteOfWork, UniteOfWork>();
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<ICachService, CachService>();
            builder.Services.AddScoped<IBasketRepository, BasketRepository>();
            builder.Services.AddScoped<IBasketService, BasketService>();
            builder.Services.AddScoped<ITokenServices, TokenServices>();
            builder.Services.AddScoped<IUserServices, UserServices>();

            builder.Services.AddAutoMapper(typeof(ProductProfile));
            builder.Services.AddAutoMapper(typeof(BasketProfile));

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerDocumentation();

            builder.Services.AddIdentityServices(builder.Configuration);


            var app = builder.Build();
            await ApplySeeding.ApplySeedingAsync(app);

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseMiddleware<ExceptionMiddleWare>();
            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseStaticFiles();//middlewear for static Files(images)
            app.MapControllers();

            app.Run();
        }
    }
}
