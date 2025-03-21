﻿using Evolvify.Application.Common.User;
using Evolvify.Application.Email.EmailServices;
using Evolvify.Application.Email.EmailSettings;
using Evolvify.Application.Token;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Evolvify.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services,IConfiguration configuration)
        {

            var applicatonsAssembly =Assembly.GetExecutingAssembly();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddValidatorsFromAssembly(applicatonsAssembly)
                .AddFluentValidationAutoValidation();

            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUserContext, UserContext>();
            services.AddTransient<IEmailService, EmailService>();

            services.Configure<MailSettings>(configuration.GetSection("MailSettings"));

            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

            services.AddAutoMapper(applicatonsAssembly);

            services.AddHttpContextAccessor();
        }
    }
}
