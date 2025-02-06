using Evolvify.Domain.Entities;
using Evolvify.Infrastructure.Data.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace Evolvify.Infrastructure.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Evolvify.Domain.Entities;
using Evolvify.Infrastructure.Data.Context;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContextService(configuration);
        services.AddIdentityService();
        return services;
        
    }

    private static IServiceCollection AddDbContextService(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<EvolvifyDbContext>(options => options.UseSqlServer(connectionString));

        return services;
    }

    private static void AddIdentityService(this IServiceCollection services)
    {
        services.AddIdentity<ApplicationUser, IdentityRole>(options =>
        {
            options.SignIn.RequireConfirmedEmail= true;
            options.Tokens.EmailConfirmationTokenProvider = TokenOptions.DefaultEmailProvider;
        })
                .AddEntityFrameworkStores<EvolvifyDbContext>()
                .AddDefaultTokenProviders();

    }

}
