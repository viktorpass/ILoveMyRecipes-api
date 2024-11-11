using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
namespace ILoveMyRecipes.Infra.Ioc {
    public static class SwaggerDI {

        public static IServiceCollection SwaggerInfrastructure(this IServiceCollection services) {

            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo {
                    Title = "ILoveMyRecipes.API",
                    Version = "v1.0"
                });
                c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme() {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JSON Web TOKEN to make my API safe and fast"
                });


                c.AddSecurityRequirement(new OpenApiSecurityRequirement() {
                    {
                        new OpenApiSecurityScheme() {
                            Reference = new OpenApiReference() {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string []{}
                    }
                });


            });
            return services;

        }
    }
}
