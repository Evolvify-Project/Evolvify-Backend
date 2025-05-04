using Evolvify.Domain.Entities;
using Evolvify.Infrastructure.Data.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text.Json;
using Evolvify.Application.DTOs.Response;
using Evolvify.API.Middlewares;
using Evolvify.Infrastructure.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using Evolvify.Domain.AppSettings;
using Evolvify.Application.Extensions;

namespace Evolvify.API.Helper
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependency(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddBuildInService();
            services.AddSwaggerService();
            services.AddInfrastructure(configuration);
            services.AddApplicationServices(configuration);
            services.MiddlewareService();
            services.AddCorsServices();
            return services;
        }
       

        private static void AddBuildInService(this IServiceCollection services) =>
             services.AddControllers();

        private static IServiceCollection AddSwaggerService(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\""
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        },

                        Name = "Bearer",
                        In = ParameterLocation.Header
                    },

                     new List<string>()
                }
            });
            });


            return services;
        }

        private static void AddCorsServices(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    policy => policy.AllowAnyOrigin()
                                   .AllowAnyMethod()
                                   .AllowAnyHeader());
            });
        }


        private static void MiddlewareService(this IServiceCollection services)
        {
            services.AddScoped<ExceptionMiddleware>();
        }
      

    }
}
