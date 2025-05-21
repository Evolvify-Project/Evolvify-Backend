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
    public class ContentSeeder
    {
        public static List<Content> GetCourses()
        {
            var typesData = File.ReadAllText(@"..\Evolvify.Infrastructure\Data\Seeding\DataSeed\Contents.json");

            // Deserialize the JSON data into a list of Course objects
            var content = JsonConvert.DeserializeObject<List<Content>>(typesData);

            if (content == null || !content.Any())
            {
                throw new NotFoundException("Content not found");
            }
            return content;
        }
    }
}