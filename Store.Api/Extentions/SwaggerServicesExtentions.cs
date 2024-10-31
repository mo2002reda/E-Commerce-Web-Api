using Microsoft.OpenApi.Models;

namespace Store.Api.Extentions
{
    public static class SwaggerServicesExtentions
    {
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "StoreAPI", Version = "v1" });
                //customize Swagger with extra extention 
                var SecurityScheme = new OpenApiSecurityScheme()
                {
                    Description = "Autherize using Bearer Scheme",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "bearer",
                    Reference = new OpenApiReference()
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "bearer"
                    }
                };
                options.AddSecurityDefinition("bearer", SecurityScheme);

                var securityRequirement = new OpenApiSecurityRequirement
                {
                    {SecurityScheme,new[]{"bearer" } }
                };

                options.AddSecurityRequirement(securityRequirement);
            }
            );
            return services;
        }
    }
}
