using Evolvify.Application.Payment.DTOs;
using Evolvify.Application.Payment.PaymentService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using Stripe.Entitlements;

namespace Evolvify.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            this.paymentService = paymentService;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("create-payment-intent")]
        public async Task<IActionResult> CreatePaymentIntent([FromBody]PaymentRequest paymentRequest)
        {
            var response = await paymentService.CreatePaymentIntentAsync(paymentRequest.Amount);
            return Ok(response);
        }

        [HttpPost("webhooks")]
        public async Task<IActionResult> Index()
        {
            var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();
            // Replace this endpoint secret with your endpoint's unique secret
            // If you are testing with the CLI, find the secret by running 'stripe listen'
            // If you are using an endpoint defined with the API or dashboard, look in your webhook settings
            // at https://dashboard.stripe.com/webhooks
            const string endpointSecret = "whsec_23f8a4716583fcf838b465290bef055990d38f27403f1bb1dd01690867182f95";
            try
            {
                var stripeEvent = EventUtility.ParseEvent(json);
                var signatureHeader = Request.Headers["Stripe-Signature"];
                stripeEvent = EventUtility.ConstructEvent(json,
                        signatureHeader, endpointSecret);
                // If on SDK version < 46, use class Events instead of EventTypes

                 if (stripeEvent.Type == EventTypes.CustomerSubscriptionCreated)
                { 
                    var subscription = stripeEvent.Data.Object as Subscription;
                    Console.WriteLine("A subscription was created.", subscription.Id);


                    await paymentService.CreateSubscriptionAsync();

                }
                else if (stripeEvent.Type == EventTypes.CustomerSubscriptionDeleted)
                {
                    var subscription = stripeEvent.Data.Object as Subscription;
                    Console.WriteLine("A subscription was canceled.", subscription.Id);

                }
                else if (stripeEvent.Type == EventTypes.CustomerSubscriptionUpdated)
                {
                    var subscription = stripeEvent.Data.Object as Subscription;
                    Console.WriteLine("A subscription was updated.", subscription.Id);

                }
                else if (stripeEvent.Type == EventTypes.CustomerSubscriptionCreated)
                {
                    var subscription = stripeEvent.Data.Object as Subscription;
                    Console.WriteLine("A subscription was created.", subscription.Id);


                    await paymentService.CreateSubscriptionAsync();

                }
                return Ok();
            }
            catch (StripeException e)
            {
                Console.WriteLine("Error: {0}", e.Message);
                return BadRequest();
            }
        }
    }
}

