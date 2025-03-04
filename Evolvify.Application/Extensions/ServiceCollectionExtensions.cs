using Evolvify.Application.Common.User;
using Evolvify.Application.Email.EmailServices;
using Evolvify.Application.Email.EmailSettings;
using Evolvify.Application.Identity.Register;
using Evolvify.Application.Skills.DTO;
using Evolvify.Application.Token;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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

            services.AddAutoMapper(applicatonsAssembly);

            services.AddHttpContextAccessor();
        }
    }
}
