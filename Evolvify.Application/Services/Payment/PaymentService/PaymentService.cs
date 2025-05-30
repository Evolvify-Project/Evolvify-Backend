using Evolvify.Application.Common.User;
using Evolvify.Application.DTOs.Response;
using Evolvify.Application.Services.Payment;
using Evolvify.Application.Services.Payment.DTOs;
using Evolvify.Application.Services.Payment.PaymentService;
using Evolvify.Domain.Entities.Assessment;
using Evolvify.Domain.Entities.User;
using Evolvify.Domain.Enums;
using Evolvify.Domain.Exceptions;
using Evolvify.Domain.Specification.Subscriptions;
using Evolvify.Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Stripe;
using Stripe.Checkout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Subscription = Evolvify.Domain.Entities.User.Subscription;

namespace Evolvify.Application.Payment.PaymentService
{
    public class PaymentService : IPaymentService
    {
        private readonly StripeSettings _stripeSettings;
        private readonly IUserContext userContext;

        private readonly IUnitOfWork unitOfWork;
        private readonly UserManager<ApplicationUser> userManager;

        public PaymentService(IOptions<StripeSettings> stripeSettings, IUserContext userContext, IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
        {
            _stripeSettings = stripeSettings.Value;
            StripeConfiguration.ApiKey = _stripeSettings.SecretKey;
            this.userContext = userContext;
            this.unitOfWork = unitOfWork;
            this.userManager = userManager;

        }


        public async Task<ApiResponse<CheckoutSessionResponse>> CreateStripeSubscriptionAsync(string priceId)
        {
            var currentUser = userContext.GetCurrentUser();
            var user = await userManager.FindByIdAsync(currentUser.Id);

            string customerId = user!.StripeCustomerId;
            if (string.IsNullOrEmpty(customerId))
            {
                var options = new CustomerCreateOptions
                {
                    Email = user.Email,
                    Name = user.UserName,
                };
                var customerService = new CustomerService();
                var customer = await customerService.CreateAsync(options);
                user.StripeCustomerId = customer.Id;
                await userManager.UpdateAsync(user);
                customerId = customer.Id;
            }


            var sessionOptions = new SessionCreateOptions
            {
                Customer = customerId,
                PaymentMethodTypes = new List<string> { "card" }, 
                Mode = "subscription", 
                LineItems = new List<SessionLineItemOptions>
                {
                new SessionLineItemOptions
                {
                    Price = priceId,
                    Quantity = 1,
                },

            },
                SuccessUrl = "https://evolvify-website.vercel.app/home", 
                CancelUrl = "https://yourdomain.com/cancel",
                
            };

            var sessionService = new SessionService();
            var session = await sessionService.CreateAsync(sessionOptions);          

            return new ApiResponse<CheckoutSessionResponse>(new CheckoutSessionResponse { CheckoutSessionUrl=session.Url});
        }
    }
}
