using Evolvify.Application.Common.User;
using Evolvify.Application.DTOs.Response;
using Evolvify.Application.Services.Payment.DTOs;
using Evolvify.Domain.Entities.User;
using Evolvify.Domain.Enums;
using Evolvify.Domain.Exceptions;
using Evolvify.Domain.Specification.Subscriptions;
using Evolvify.Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Subscription = Evolvify.Domain.Entities.User.Subscription;

namespace Evolvify.Application.Services.AppSubscription
{
    public class AppSubscriptionService : IAppSubscriptionService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IUnitOfWork unitOfWork;
        private readonly IUserContext userContext;
        public AppSubscriptionService(UserManager<ApplicationUser> userManager, IUnitOfWork unitOfWork, IUserContext userContext)
        {
            this.userManager = userManager;
            this.unitOfWork = unitOfWork;
            this.userContext = userContext;

        }

        public async Task ActivateSubscriptionAsync(string stripeSubscriptionId)
        {
            var subscriptionService = new SubscriptionService();
            var subscription = await subscriptionService.GetAsync(stripeSubscriptionId);

            var interval = subscription.Items.Data.FirstOrDefault()?.Price?.Recurring?.Interval;

            var user = await userManager.Users
                .Include(u => u.Subscription)
                .FirstOrDefaultAsync(u => u.StripeCustomerId == subscription.CustomerId);

            if (user == null)
            {
                throw new NotFoundException("User not found with the provided Stripe Customer ID.");
            }

            // Check if the user already has an active subscription
            var newSubscription = new Subscription
            {
                UserId = user.Id,
                StripeSubscriptionId = stripeSubscriptionId,
                StartDate = DateTime.UtcNow,
                EndDate = interval switch
                {
                    "month" => DateTime.UtcNow.AddMonths(1),
                    "year" => DateTime.UtcNow.AddYears(1),
                    _ => DateTime.UtcNow.AddMonths(1), // Default to 3 months if interval is not recognized
                },
                Status = SubscriptionStatus.Active,
                PlanType = PlanType.Premium,
                Interval = interval,
            };

            await unitOfWork.Repository<Subscription, int>().CreateAsync(newSubscription);
            await unitOfWork.CompleteAsync();

        }


        public async Task<ApiResponse<SubscriptionStatusDto>> GetSubscriptionStatusAsync()
        {
            var currentUser = userContext.GetCurrentUser();

            var spec = new UserSubscriptionSpecification(currentUser.Id);
            var subscription = await unitOfWork.Repository<Subscription, int>().GetByIdWithSpec(spec);

            if (subscription == null)
            {
                throw new NotFoundException("No subscription found for the current user.");
            }

            var statusDto = new SubscriptionStatusDto
            {
                Plan = subscription.PlanType.ToString(),
                Status = subscription.Status.ToString(),
                IsActive =  subscription.Status == SubscriptionStatus.Active,
                StartDate = subscription.StartDate.ToString("yyyy-MM-dd"),
                EndDate = subscription.EndDate.ToString("yyyy-MM-dd"),
                RemainingDays = (int)(Math.Ceiling((subscription.EndDate - DateTime.UtcNow).TotalDays))
            };
            return new ApiResponse<SubscriptionStatusDto>(statusDto);

        }

        public async Task UpdateExpiredSubscriptionsAsync()
        {
           var spec=new ExpiredSubscriptionSpacification();
            var expiredSubscriptions = await unitOfWork.Repository<Subscription, int>().GetAllWithSpec(spec);

            foreach (var subscription in expiredSubscriptions)
            {
                subscription.Status = SubscriptionStatus.Expired;
                unitOfWork.Repository<Subscription, int>().Update(subscription);
            }

            await unitOfWork.CompleteAsync();
            
        }
    }
}
