using Evolvify.Domain.AppSettings;
using Evolvify.Domain.Constants;
using Evolvify.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    TrialStartDate = DateTime.UtcNow,
                    TrialEndDate = DateTime.UtcNow.AddDays(7)

                };

                var userExists = await userManager.FindByEmailAsync(user.Email);

                if(userExists!=null)
                {
                    continue;
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
