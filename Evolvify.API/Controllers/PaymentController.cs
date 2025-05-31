using Evolvify.Application.Services.AppSubscription;
using Evolvify.Application.Services.Payment;
using Evolvify.Application.Services.Payment.PaymentService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Stripe;
using Stripe.Entitlements;

namespace Evolvify.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService paymentService;
        private readonly IAppSubscriptionService appSubscriptionService;
        private readonly IConfiguration configuration;
        private readonly string _webhookSecret;

        public PaymentController(IPaymentService paymentService, IConfiguration configuration, IOptions<StripeSettings> stripeSettings,IAppSubscriptionService appSubscriptionService)
        {

            _webhookSecret = stripeSettings.Value.WebhookSecret;
            this.configuration = configuration;
            this.paymentService = paymentService;
            this.appSubscriptionService = appSubscriptionService;
            StripeConfiguration.ApiKey = stripeSettings.Value.SecretKey;
        }

        [HttpGet("GetSubscriptionPlans")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetSubscriptionPlans()
        {
            var response = await appSubscriptionService.GetSubscriptionPlansAsync();
            return Ok(response);
        }
        
        [HttpPost("create-subscription")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> CreateSubscription([FromBody] string priceId)
        {
            var response = await paymentService.CreateStripeSubscriptionAsync(priceId);
            return Ok(response);
        }


        [HttpPost("webhook")]
        public async Task<IActionResult> Webhook()
        {
            var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();
            Event stripeEvent;
            try
            {
                stripeEvent = EventUtility.ConstructEvent(
                  json,
                  Request.Headers["Stripe-Signature"],
                  _webhookSecret,
                  throwOnApiVersionMismatch: false
                );
                Console.WriteLine($"Webhook notification with type: {stripeEvent.Type} found for {stripeEvent.Id}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Something failed {e}");
                return BadRequest();
            }

            // This event is sent when a new subscription is created.
            if (stripeEvent.Type == "checkout.session.completed")
            {
                // Handle the event
                // Retrieve the session object from the event data
                var session = stripeEvent.Data.Object as Stripe.Checkout.Session;

                if (session != null)
                {
                    // Log the session details
                    var subscriptionId = session.SubscriptionId;

                    await appSubscriptionService.ActivateSubscriptionAsync(subscriptionId);
                }
            }

            
            return Ok();
        }


        [HttpGet("subscription-status")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetSubscriptionStatus()
        {
            var response = await appSubscriptionService.GetSubscriptionStatusAsync();
            return Ok(response);
        }
    }
}
