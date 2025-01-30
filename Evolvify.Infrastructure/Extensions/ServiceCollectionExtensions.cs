using Evolvify.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace Evolvify.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddDbContextService(configuration);
        
        return services;
    }

    private static IServiceCollection AddDbContextService(this IServiceCollection services,IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<EvolvifyDbContext>(options => options.UseSqlServer(connectionString));
        
        return services;
    }

    private static IServiceCollection AddIdentityService(this IServiceCollection services)
    {
       
        return services;
    }
}
