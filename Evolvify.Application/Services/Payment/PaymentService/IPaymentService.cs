using Evolvify.Application.DTOs.Response;
using Evolvify.Application.Services.Payment.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Services.Payment.PaymentService
{
    public interface IPaymentService
    {

        Task<ApiResponse<StripeSubscriptionResponse>> CreateStripeSubscriptionAsync(string priceId);
    }
}
