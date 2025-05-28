using Evolvify.Domain.AppSettings;
using Evolvify.Domain.Constants;
using Evolvify.Domain.Entities.User;
using Evolvify.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Evolvify.Infrastructure.Data.Seeding.Role
{
    public static class RoleSeeder
    {

        public static async Task SeedRolesAsync(IServiceProvider serviceProvider,IOptions<SeedUsersSettings> seedUsersSettings)
        {
            var roleManager=serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager=serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            //var users = configuration.GetSection("SeedUsers").Get<List<SeedUser>>();


            string [] roles = new [] { "Admin", "Instructor", "User" };

            foreach (string role in roles)
            {
                if(! await roleManager.RoleExistsAsync(role))
                {
                   await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

           var users=seedUsersSettings.Value.SeedUsers;

            foreach (var seedUser in users)
            {
                var user = new ApplicationUser
                {

                    Email = seedUser.Email,
                    UserName = seedUser.UserName,
                    EmailConfirmed = true,
                    Subscription= new Subscription
                    {
                        PlanType = seedUser.PlanType,
                        StartDate = DateTime.UtcNow,
                        EndDate = seedUser.EndDate,
                        Status = SubscriptionStatus.Active.ToString()
                    },
                    
                };


                if (await userManager.FindByEmailAsync(user.Email) != null)
                {
                    continue; // User already exists, skip to the next one
                }

               
                var result = await userManager.CreateAsync(user, seedUser.Password);

                if(result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, seedUser.Role);
                }
            }
            
        }
    }
}
