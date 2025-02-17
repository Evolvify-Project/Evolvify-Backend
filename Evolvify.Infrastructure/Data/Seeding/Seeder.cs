﻿using Evolvify.Domain.Entities;
using Evolvify.Infrastructure.Data.Context;
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
            if(context.Database.GetPendingMigrations().Any())
            {
               await context.Database.MigrateAsync();

            }

            if (await context.Database.CanConnectAsync())
            {
                if (!context.Skills.Any())
                {
                    var skills =SkillSeeder.GetSkills();
                    await context.Skills.AddRangeAsync(skills);
                    await context.SaveChangesAsync();
                }
            }
        }

       
    }
}
