using Evolvify.Domain.Entities;
using Evolvify.Domain.Enums;
using Evolvify.Domain.Exceptions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Evolvify.Infrastructure.Data.Seeding.Skills
{
    public class SkillSeeder
    {
        public static List<Skill> GetSkills()
        {
            var typesData=File.ReadAllText(@"..\Evolvify.Infrastructure\Data\Seeding\DataSeed\Skills.json");

            var Skills=JsonConvert.DeserializeObject<List<Skill>>(typesData);


            if (Skills == null ||!Skills.Any())
            {
                throw new NotFoundException("Skills not found");
            }
            return Skills;
           
        }
    }
}
