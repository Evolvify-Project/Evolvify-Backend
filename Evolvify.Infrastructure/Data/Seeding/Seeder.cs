using Evolvify.Domain.Entities;
using Evolvify.Infrastructure.Data.Context;
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
                    var skills = GetSkills();
                    await context.Skills.AddRangeAsync(skills);
                    await context.SaveChangesAsync();
                }
            }
        }

        private List<Skill> GetSkills()
        {
            var skillList = new List<Skill>
            {
                new Skill()
                {
                    Name = "Communication Skills",
                    Description = "The ability to clearly express ideas, actively listen, and engage in effective verbal and written communication.",

                },
                new Skill
                {
                    Name="Interview Skills",
                    Description="Techniques and strategies for confidently handling job interviews, answering questions effectively, and presenting oneself professionally."

                },
                new Skill
                {
                    Name="Teamwork",
                    Description="The ability to collaborate with others, work efficiently in a team environment, and contribute to group success."

                },
                new Skill
                {
                    Name="Presentation Skills",
                    Description="The capability to create and deliver engaging presentations with confidence, clarity, and impact."

                },
                new Skill
                {
                    Name="Time Management",
                    Description="The skill of prioritizing tasks, managing deadlines, and optimizing productivity for efficient work completion.\r\n"

                }
            };

            return skillList;
           
        }
    }
}
