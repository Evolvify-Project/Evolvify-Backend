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


        public async Task<ApiResponse<StripeSubscriptionResponse>> CreateStripeSubscriptionAsync(string priceId)
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
            var subscriptionOptions = new SubscriptionCreateOptions
            {
                Customer = customerId,
                Items = new List<SubscriptionItemOptions>
                {
                    new SubscriptionItemOptions
                    {
                        Price = priceId,
                    },
                },
                PaymentBehavior = "default_incomplete",
                Expand = new List<string> { "latest_invoice.confirmation_secret" },
            };

            var subscriptionService = new SubscriptionService();
            var existingSubscriptions = await subscriptionService.ListAsync(new SubscriptionListOptions
            {
                Customer = customerId,
                Status = "active"
            });

            bool hasActiveSubscription = existingSubscriptions.Data.Any(sub => sub.Items.Data.Any(item => item.Price.Id == priceId));
            if (hasActiveSubscription)
            {
                return new ApiResponse<StripeSubscriptionResponse>(false, StatusCodes.Status400BadRequest, message: "You already have an active subscription for this plan.");
            }

            var subscription = await subscriptionService.CreateAsync(subscriptionOptions);
            var response = new StripeSubscriptionResponse
            {
                StripeSubscriptionId = subscription.Id,
                ClientSecret = subscription.LatestInvoice.ConfirmationSecret.ClientSecret,
                StripeCustomerId = customerId,
            };

            return new ApiResponse<StripeSubscriptionResponse>(response);


        }

    }
}
