using Evolvify.Domain.Entities;
using Evolvify.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Infrastructure.Data.Seeding.Skills
{
    public class CourseSeeder
    {

        public static List<Course> GetCourses()
        {
            var courses = new List<Course>
            {
                new Course
                {
                    Title = "Mastering Communication",
                    Description = "Advanced techniques in effective communication",
                    Level = Level.Advanced,
                    SkillId = 1,
                    CreatedAt = DateTime.Now,
                    Duration = 120,
                    ImageUrl = "https://example.com/images/communication.jpg"
                },
                new Course
                {
                    Title = "Ace the Interview",
                    Description = "Comprehensive interview preparation course",
                    Level = Level.Beginner,
                    SkillId = 2,
                    CreatedAt = DateTime.Now,
                    Duration = 90,
                    ImageUrl = "https://example.com/images/interview.jpg"
                },
                new Course
                {
                    Title = "Teamwork Essentials",
                    Description = "Learn how to collaborate effectively with team members",
                    Level = Level.Beginner,
                    SkillId = 3,
                    CreatedAt = DateTime.Now,
                    Duration = 100,
                    ImageUrl = "https://example.com/images/teamwork.jpg"
                },
                new Course
                {
                    Title = "Presentation Pro",
                    Description = "Craft and deliver compelling presentations",
                    Level = Level.Intermediate,
                    SkillId = 4,
                    CreatedAt = DateTime.Now,
                    Duration = 110,
                    ImageUrl = "https://example.com/images/presentation.jpg"
                },
                new Course
                {
                    Title = "Time Management 101",
                    Description = "Manage your time and tasks efficiently",
                    Level = Level.Beginner,
                    SkillId = 5,
                    CreatedAt = DateTime.Now,
                    Duration = 80,
                    ImageUrl = "https://example.com/images/time.jpg"
                }
            };

            return courses;

        }
    }
}
