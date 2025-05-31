using Evolvify.Domain.Entities.User;
using Evolvify.Domain.Enums;
using Evolvify.Infrastructure.Data.Context;
using Evolvify.Infrastructure.UnitOfWork;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Infrastructure.Data.Seeding.DataSeeder.StripePlan
{
    public class SubscriptionPlanSeeder
    {
        
        private readonly EvolvifyDbContext _context;

        public SubscriptionPlanSeeder(EvolvifyDbContext context)
        {
            _context = context;
        }

        public static async Task<List<SubscriptionPlan>> GetSubscriptionPlans()
        {
            var productService = new ProductService();
            var product= await productService.GetAsync("prod_SPHrXXeJNTRptB"); // Replace with your actual product ID
            var options = new PriceListOptions
            {
                Product = product.Id ,// Get the first product's ID
                Active = true,
                Limit = 5, // Adjust the limit as needed
            };
            var priceServic = new PriceService();
            var prices = await priceServic.ListAsync(options);
            var subscriptionPlans = new List<SubscriptionPlan>();

            foreach (var price in prices)
            {                
                var subscriptionPlan = new SubscriptionPlan
                {
                    Name = product.Name,
                    StripePriceId = price.Id,
                    Price = price.UnitAmount.HasValue ? (decimal)price.UnitAmount.Value / 100 : 0, // Convert cents to dollars
                    Currency = price.Currency,
                    Interval = price.Recurring?.Interval == "month" ? SubscriptionInterval.Monthly : SubscriptionInterval.Yearly,
                    Description = price.Nickname ?? "No description available",
                };
                subscriptionPlans.Add(subscriptionPlan);
                
            }
            return subscriptionPlans;
        }
    }
}
