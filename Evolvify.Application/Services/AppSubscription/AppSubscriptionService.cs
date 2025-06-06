﻿using AutoMapper;
using Evolvify.Application.Common.User;
using Evolvify.Application.DTOs.Response;
using Evolvify.Application.Services.AppSubscription.DTOs;
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
        private readonly IMapper mapper;
        public AppSubscriptionService(UserManager<ApplicationUser> userManager, IUnitOfWork unitOfWork, IUserContext userContext, IMapper mapper)
        {
            this.userManager = userManager;
            this.unitOfWork = unitOfWork;
            this.userContext = userContext;
                this.mapper = mapper;

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

            
            // If the user already has an active subscription, we can update it

            // Check if the user already has an active subscription
            var existingSubscription = await unitOfWork.Repository<Subscription, int>()
                .GetByIdWithSpec(new UserSubscriptionSpecification(user.Id));

            if (existingSubscription == null)
            {
                // If no existing subscription, create a new one
                existingSubscription = new Subscription
                {
                    UserId = user.Id,
                    Status = SubscriptionStatus.Active,
                    StripeSubscriptionId = subscription.Id,
                    StripePriceId = subscription.Items.Data.FirstOrDefault()?.Price?.Id,
                    PlanType = PlanType.Premium,
                    StartDate = DateTime.UtcNow,
                    EndDate = interval == "month"
                        ? DateTime.UtcNow.AddMonths(1)
                        : DateTime.UtcNow.AddYears(1),
                    Interval = interval == "month" ? SubscriptionInterval.Monthly : SubscriptionInterval.Yearly
                };
                await unitOfWork.Repository<Subscription, int>().CreateAsync(existingSubscription);

                await unitOfWork.CompleteAsync();
            }
            
                // Update existing subscription details
                existingSubscription.StripeSubscriptionId = subscription.Id;
                existingSubscription.StripePriceId = subscription.Items.Data.FirstOrDefault()?.Price?.Id;
                existingSubscription.Status = SubscriptionStatus.Active;
                existingSubscription.StripeSubscriptionId = subscription.Id;
                existingSubscription.StripePriceId = subscription.Items.Data.FirstOrDefault()?.Price?.Id;
                existingSubscription.PlanType = PlanType.Premium;
                existingSubscription.StartDate = DateTime.UtcNow;
                existingSubscription.EndDate = interval == "month"
                    ? DateTime.UtcNow.AddMonths(1)
                    : DateTime.UtcNow.AddYears(1);
                existingSubscription.Interval= interval == "month" ? SubscriptionInterval.Monthly : SubscriptionInterval.Yearly;


             unitOfWork.Repository<Subscription, int>().Update(existingSubscription);
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

           var statusDto = mapper.Map<SubscriptionStatusDto>(subscription);
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

        public async Task<ApiResponse<List<SubscriptionPlanDto>>> GetSubscriptionPlansAsync()
        {
            var subscriptionPlans=await unitOfWork.Repository<SubscriptionPlan,int>().GetAllAsync();

            if (subscriptionPlans == null|| !subscriptionPlans.Any())
            {
                throw new NotFoundException("SubscriptionPlans Not Found");
            }

            var plansDto=  mapper.Map<List<SubscriptionPlanDto>>(subscriptionPlans);

            return new ApiResponse<List<SubscriptionPlanDto>>(plansDto);

             
        }

    }
}
