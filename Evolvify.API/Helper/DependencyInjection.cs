using Evolvify.Application.Extensions;
using Evolvify.Domain.Entities;
using Evolvify.Infrastructure.Data.Context;
using Microsoft.AspNetCore.Identity;

namespace Evolvify.API.Helper
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependency(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentityService();
            services.AddBuildInService();
            services.AddSwaggerService();
            services.AddApplicationServices();
            return services;
        }
        private static void AddIdentityService(this IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, IdentityRole>()
                    .AddEntityFrameworkStores<EvolvifyDbContext>()
                    .AddDefaultTokenProviders();

        }

        private static void AddBuildInService(this IServiceCollection services) =>
             services.AddControllers();

        private static void AddSwaggerService(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }
    }
}
