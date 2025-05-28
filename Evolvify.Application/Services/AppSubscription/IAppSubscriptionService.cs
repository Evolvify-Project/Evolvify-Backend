using Evolvify.Application.DTOs.Response;
using Evolvify.Application.Services.AppSubscription.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Services.AppSubscription
{
    public interface IAppSubscriptionService
    {
        Task ActivateSubscriptionAsync(string stripeSubscriptionId);
        Task<ApiResponse<SubscriptionStatusDto>> GetSubscriptionStatusAsync();
        Task UpdateExpiredSubscriptionsAsync();
    }
}
