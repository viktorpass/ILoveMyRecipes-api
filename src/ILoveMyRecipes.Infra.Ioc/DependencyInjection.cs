using AutoMapper;
using ILoveMyRecipes.Application.Account;
using ILoveMyRecipes.Application.Interfaces;
using ILoveMyRecipes.Application.Mappings;
using ILoveMyRecipes.Application.Services;
using ILoveMyRecipes.Domain.Interfaces;
using ILoveMyRecipes.Infra.Data.Context;
using ILoveMyRecipes.Infra.Data.Identity;
using ILoveMyRecipes.Infra.Data.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;


namespace ILoveMyRecipes.Infra.Ioc {
    public static class DependencyInjection {

        public static IServiceCollection Persistence(this IServiceCollection services, IConfiguration configuration) {

            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));

            // JWT

            services.AddAuthentication(opt => {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }
            ).AddJwtBearer(options => {
                options.TokenValidationParameters = new TokenValidationParameters {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = configuration["jwt:issuer"],
                    ValidAudience = configuration["jwt:audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(configuration["jwt:secretKey"])),
                    ClockSkew = TimeSpan.Zero
                };
            });

            services.AddScoped<IRecipeRepository, RecipeRepository>();
            services.AddScoped<IRecipeTypeRepository, RecipeTypeRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IRecipeService, RecipeService>();
            services.AddScoped<IRecipeTypeService, RecipeTypeService>();           
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthenticate, AuthenticateService>();
            services.AddAutoMapper(typeof(MappingProfiles));
            
            
            return services;
        }



    }
}
