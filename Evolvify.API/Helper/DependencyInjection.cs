using Evolvify.Application.Extensions;
using Evolvify.Domain.Entities;
using Evolvify.Infrastructure.Data.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text.Json;
using Evolvify.Application.DTOs.Response;
using Evolvify.API.Middlewares;
using Evolvify.Infrastructure.Extensions;

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
            services.AddValiadiationErrorHandlingServices();

            services.MiddlewareService();
            return services;
        }
       

        private static void AddBuildInService(this IServiceCollection services) =>
             services.AddControllers();

        private static void AddSwaggerService(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }
        private static void MiddlewareService(this IServiceCollection services)
        {
            services.AddScoped<ExceptionMiddleware>();
        }
        private static void AddValiadiationErrorHandlingServices(this IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(options =>
            {

                options.InvalidModelStateResponseFactory = actionContext =>
                {
                    var errors = actionContext.ModelState
                        .Where(e => e.Value.Errors.Count > 0)
                        .SelectMany(x => x.Value.Errors)
                        .Select(x => x.ErrorMessage).ToList();

                    var result = new ApiResponse<string>(
                        success: false,
                        statusCode: 400,
                        message: "Validation errors",
                        errors: errors
                        );


                    return new BadRequestObjectResult(result);
                };



            });
        }
    }
}
