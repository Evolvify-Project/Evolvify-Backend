using Evolvify.Application.Services.AppSubscription;
using Hangfire;

namespace Evolvify.API.Helper
{
    public static class HangfireJobsRegistration
    {
        public static void RegisterHangfireJobs()
        {
          
            // Register recurring job for updating subscription status
            RecurringJob.AddOrUpdate<IAppSubscriptionService>(
           "update-subscription-status",
           service => service.UpdateExpiredSubscriptionsAsync(),
           Cron.Daily());

            ////example of recurring job for payment processing console.writeLine("Recurring job for payment processing started");
            //RecurringJob.AddOrUpdate(() => Console.WriteLine("Recurring job for payment processing started"), Cron.Minutely());
        }
    }
}
