using Evolvify.Domain.Entities;
using Evolvify.Infrastructure.Data.Context;
using Evolvify.Infrastructure.Data.Seeding.DataSeeder;
using Evolvify.Infrastructure.Data.Seeding.DataSeeder.StripePlan;
using Evolvify.Infrastructure.Data.Seeding.Skills;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Infrastructure.Data.Seeding
{
    public class Seeder : ISeeder
    {
        private readonly EvolvifyDbContext context;

        public Seeder(EvolvifyDbContext context)
        {
            this.context = context;
        }

        public async Task SeedAsync()
        {
            if (await context.Database.CanConnectAsync())
            {
                if (!context.Skills.Any())
                {
                    var skills = SkillSeeder.GetSkills();
                    await context.Skills.AddRangeAsync(skills);
                    await context.SaveChangesAsync();
                }
                if (!context.Courses.Any())
                {
                    var courses=CourseSeeder.GetCourses();
                    await context.Courses.AddRangeAsync(courses);
                    await context.SaveChangesAsync();
                }
                if (!context.Modules.Any())
                {
                    var modules = ModuleSeeder.GetModules();
                    await context.Modules.AddRangeAsync(modules);
                    await context.SaveChangesAsync();
                }

                if (!context.Contents.Any())
                {
                    var contents = await ContentSeeder.GetContents();
                    await context.Contents.AddRangeAsync(contents);
                    await context.SaveChangesAsync();
                }

                var existingPlans = await context.SubscriptionPlans.Select(p => p.StripePriceId).ToListAsync();
                var allPlans = await SubscriptionPlanSeeder.GetSubscriptionPlans();

                var newPlans = allPlans
                    .Where(plan => !existingPlans.Contains(plan.StripePriceId))
                    .ToList();

                if (newPlans.Any())
                {
                    await context.SubscriptionPlans.AddRangeAsync(newPlans);
                    await context.SaveChangesAsync();
                }
            }
        }

       
    }
}
