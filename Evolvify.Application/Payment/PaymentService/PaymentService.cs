using Evolvify.Application.Common.User;
using Evolvify.Application.DTOs.Response;
using Evolvify.Application.Payment.DTOs;
using Evolvify.Domain.Entities.Assessment;
using Evolvify.Domain.Entities.User;
using Evolvify.Domain.Enums;
using Evolvify.Infrastructure.UnitOfWork;
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

        public PaymentService(IOptions<StripeSettings> stripeSettings,IUserContext userContext,IUnitOfWork unitOfWork)
        {
           _stripeSettings = stripeSettings.Value;
            StripeConfiguration.ApiKey = _stripeSettings.SecretKey;
            this.userContext = userContext;
            this.unitOfWork = unitOfWork;

        }
        public async Task<ApiResponse<PaymentIntentResponse>> CreatePaymentIntentAsync(decimal amount)
        {
            
            var options= new PaymentIntentCreateOptions
            {
                
                Amount =(long) (amount * 100), // Amount in cents
                Currency = "usd",
                PaymentMethodTypes = new List<string>
                {
                    "card",
                },
            };

            var service = new PaymentIntentService();
            var paymentIntent = await service.CreateAsync(options);

            var response = new PaymentIntentResponse
            {
                ClientSecret = paymentIntent.ClientSecret,
                PaymentIntentId = paymentIntent.Id,
            };

            return new ApiResponse<PaymentIntentResponse>(response);

        }

        public async Task CreateSubscriptionAsync()
        {
            
            var subscription = new Subscription
            {
                UserId = userContext.GetCurrentUser().Id,
                Status = SubscriptionStatus.Active.ToString(),
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddMonths(3),
                PlanType = PlanType.Premium.ToString(),
            };
            var user = unitOfWork.Repository<Subscription,int>().CreateAsync(subscription);
            await unitOfWork.CompleteAsync();


        }
    }
}
