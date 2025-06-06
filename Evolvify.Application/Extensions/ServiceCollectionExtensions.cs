﻿using Evolvify.Application.Assessment.Service;
using Evolvify.Application.Common.Services;
using Evolvify.Application.Common.User;
using Evolvify.Application.Community.Posts.DTOs;
using Evolvify.Application.DTOs.Response;
using Evolvify.Application.Email.EmailServices;
using Evolvify.Application.Email.EmailSettings;
using Evolvify.Application.Identity.UserProfile.Mapping;
using Evolvify.Application.Payment.PaymentService;
using Evolvify.Application.Services.AppSubscription;
using Evolvify.Application.Services.Payment;
using Evolvify.Application.Services.Payment.PaymentService;
using Evolvify.Application.Token;
using Evolvify.Domain.AppSettings;
using Evolvify.Domain.Interfaces.ImageInterface;
using FluentValidation;
using FluentValidation.AspNetCore;
using Hangfire;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Stripe;
using System.Reflection;
using FileService = Evolvify.Application.Common.Services.FileService;
using JwtSettings = Evolvify.Domain.AppSettings.JwtSettings;
using TokenService = Evolvify.Application.Token.TokenService;

namespace Evolvify.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {

        public static void AddApplicationServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddHttpContextAccessor();
            var applicatonsAssembly =Assembly.GetExecutingAssembly();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddValidatorsFromAssembly(applicatonsAssembly)
                .AddFluentValidationAutoValidation();

            services.AddValiadiationErrorHandlingServices();

            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUserContext, UserContext>();
            services.AddScoped<IAssessmentApiService, AssessmentApiService>();
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IAppSubscriptionService, AppSubscriptionService>();
           



            services.AddTransient<IEmailService, EmailService>();

            services.Configure<MailSettings>(configuration.GetSection("MailSettings"));

            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

            services.Configure<SeedUsersSettings>(configuration.GetSection("SeedUsersSettings"));
            services.Configure<StripeSettings>(configuration.GetSection("StripeSettings"));

            services.AddAutoMapper(applicatonsAssembly);
            services.AddAutoMapper(typeof(UserProfile));

            services.AddHttpContextAccessor();

            services.AddHangfireServices(configuration);
            

            StripeConfiguration.ApiKey = configuration["StripeSettings:SecretKey"];

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

        private static void AddHangfireServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHangfire(config =>
            {
                config.UseSqlServerStorage(configuration.GetConnectionString("Remote"));
            });

            services.AddHangfireServer();

           


        }
    }
}
