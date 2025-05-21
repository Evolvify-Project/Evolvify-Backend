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
    public class CourseSeeder
    {
        public static List<Course> GetCourses()
        {
            var typesData = File.ReadAllText(@"..\Evolvify.Infrastructure\Data\Seeding\DataSeed\Courses.json");


            // Deserialize the JSON data into a list of Course objects
            var courses = JsonConvert.DeserializeObject<List<Course>>(typesData);



            if (courses == null || !courses.Any())
            {
                throw new NotFoundException("Courses not found");
            }
            return courses;
        }
    }
}