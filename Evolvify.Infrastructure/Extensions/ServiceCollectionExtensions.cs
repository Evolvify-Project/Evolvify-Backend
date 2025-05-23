using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
namespace Evolvify.Infrastructure.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Evolvify.Infrastructure.Data.Context;
using Evolvify.Infrastructure.Data.Seeding;
using Evolvify.Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Http;
using Evolvify.Application.DTOs.Response;
using Evolvify.Application.Assessment.Service;
using Evolvify.Domain.Entities.User;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContextService(configuration);
        services.AddIdentityService();
        services.AddUserDefindService();
        services.AddAuthenticationService(configuration);
        services.AddAuthorizationService();
        services.AddHttpClientService();


        return services;

    }

    private static void AddHttpClientService(this IServiceCollection services)
    {
        services.AddHttpClient();
       

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
            options.Tokens.EmailConfirmationTokenProvider = TokenOptions.DefaultEmailProvider;
            options.Tokens.PasswordResetTokenProvider = TokenOptions.DefaultEmailProvider;
        })
                .AddEntityFrameworkStores<EvolvifyDbContext>()
                .AddDefaultTokenProviders();

    }

    private static void AddUserDefindService(this IServiceCollection services)
    {
       services.AddScoped<ISeeder,Seeder>();
       services.AddScoped<IUnitOfWork,UnitOfWork>();

    }

    

    private static IServiceCollection AddAuthenticationService(this IServiceCollection services,IConfiguration configuration)
    {

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            
            .AddJwtBearer(options =>
            {
                options.Events = new JwtBearerEvents
                {
                    OnChallenge = async context =>
                    {
                        context.HandleResponse(); 
                        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                        context.Response.ContentType = "application/json";

                        var response = new ApiResponse<string>(false, StatusCodes.Status401Unauthorized, "Unauthorized! Please log in.",null);
                        
                        await context.Response.WriteAsJsonAsync(response);
                    }
                };
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer =configuration["JwtSettings:Issuer"],
                    ValidAudience = configuration["JwtSettings:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Secret"]))
                };


            });

        return services;
        
    }
    private static IServiceCollection AddAuthorizationService(this IServiceCollection services)
    {

        services.AddAuthorization();

        return services;
    }

}
