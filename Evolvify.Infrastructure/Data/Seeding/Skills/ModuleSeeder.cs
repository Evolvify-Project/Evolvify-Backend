using Evolvify.Domain.Entities;
using Evolvify.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Infrastructure.Data.Seeding.Skills
{
    public static class ModuleSeeder
    {
        public static List<Module> GetModules()
        {

            var modules = new List<Module>
            {
                // Modules for Course 1 (Mastering Communication)
                new Module { Title = "Module 1 - Basics of Communication", CourseId = 1, CreatedAt = DateTime.Now },
                new Module { Title = "Module 2 - Listening Skills", CourseId = 1, CreatedAt = DateTime.Now },
                new Module { Title = "Module 3 - Verbal Communication", CourseId = 1, CreatedAt = DateTime.Now },
                new Module { Title = "Module 4 - Non-Verbal Cues", CourseId = 1, CreatedAt = DateTime.Now },
                new Module { Title = "Module 5 - Barriers to Communication", CourseId = 1, CreatedAt = DateTime.Now },
                new Module { Title = "Module 6 - Emotional Intelligence", CourseId = 1, CreatedAt = DateTime.Now },
                new Module { Title = "Module 7 - Feedback Techniques", CourseId = 1, CreatedAt = DateTime.Now },
                new Module { Title = "Module 8 - Public Speaking", CourseId = 1, CreatedAt = DateTime.Now },
                new Module { Title = "Module 9 - Conflict Resolution", CourseId = 1, CreatedAt = DateTime.Now },
                new Module { Title = "Module 10 - Practice Scenarios", CourseId = 1, CreatedAt = DateTime.Now },

                // Modules for Course 2 (Ace the Interview)
                new Module { Title = "Module 1 - Preparing for Interviews", CourseId = 2, CreatedAt = DateTime.Now },
                new Module { Title = "Module 2 - Researching Companies", CourseId = 2, CreatedAt = DateTime.Now },
                new Module { Title = "Module 3 - Resume Tips", CourseId = 2, CreatedAt = DateTime.Now },
                new Module { Title = "Module 4 - Common Questions", CourseId = 2, CreatedAt = DateTime.Now },
                new Module { Title = "Module 5 - STAR Technique", CourseId = 2, CreatedAt = DateTime.Now },
                new Module { Title = "Module 6 - Body Language", CourseId = 2, CreatedAt = DateTime.Now },
                new Module { Title = "Module 7 - Dressing for Success", CourseId = 2, CreatedAt = DateTime.Now },
                new Module { Title = "Module 8 - Mock Interviews", CourseId = 2, CreatedAt = DateTime.Now },
                new Module { Title = "Module 9 - Online Interviews", CourseId = 2, CreatedAt = DateTime.Now },
                new Module { Title = "Module 10 - Follow-up Etiquette", CourseId = 2, CreatedAt = DateTime.Now },

                // Modules for Course 3 (Teamwork Essentials)
                new Module { Title = "Module 1 - Introduction to Teamwork", CourseId = 3, CreatedAt = DateTime.Now },
                new Module { Title = "Module 2 - Team Roles", CourseId = 3, CreatedAt = DateTime.Now },
                new Module { Title = "Module 3 - Communication in Teams", CourseId = 3, CreatedAt = DateTime.Now },
                new Module { Title = "Module 4 - Conflict Management", CourseId = 3, CreatedAt = DateTime.Now },
                new Module { Title = "Module 5 - Collaboration Tools", CourseId = 3, CreatedAt = DateTime.Now },
                new Module { Title = "Module 6 - Leadership in Teams", CourseId = 3, CreatedAt = DateTime.Now },
                new Module { Title = "Module 7 - Trust Building", CourseId = 3, CreatedAt = DateTime.Now },
                new Module { Title = "Module 8 - Feedback & Improvement", CourseId = 3, CreatedAt = DateTime.Now },
                new Module { Title = "Module 9 - Team Productivity", CourseId = 3, CreatedAt = DateTime.Now },
                new Module { Title = "Module 10 - Real-Life Case Studies", CourseId = 3, CreatedAt = DateTime.Now },

                // Modules for Course 4 (Presentation Pro)
                new Module { Title = "Module 1 - What is a Good Presentation?", CourseId = 4, CreatedAt = DateTime.Now },
                new Module { Title = "Module 2 - Audience Analysis", CourseId = 4, CreatedAt = DateTime.Now },
                new Module { Title = "Module 3 - Slide Design", CourseId = 4, CreatedAt = DateTime.Now },
                new Module { Title = "Module 4 - Storytelling Techniques", CourseId = 4, CreatedAt = DateTime.Now },
                new Module { Title = "Module 5 - Visual Aids", CourseId = 4, CreatedAt = DateTime.Now },
                new Module { Title = "Module 6 - Voice & Tone", CourseId = 4, CreatedAt = DateTime.Now },
                new Module { Title = "Module 7 - Handling Q&A", CourseId = 4, CreatedAt = DateTime.Now },
                new Module { Title = "Module 8 - Body Language", CourseId = 4, CreatedAt = DateTime.Now },
                new Module { Title = "Module 9 - Practice & Rehearsal", CourseId = 4, CreatedAt = DateTime.Now },
                new Module { Title = "Module 10 - Presentation Day Tips", CourseId = 4, CreatedAt = DateTime.Now },

                // Modules for Course 5 (Time Management 101)
                new Module { Title = "Module 1 - Time Management Basics", CourseId = 5, CreatedAt = DateTime.Now },
                new Module { Title = "Module 2 - Setting SMART Goals", CourseId = 5, CreatedAt = DateTime.Now },
                new Module { Title = "Module 3 - Prioritization Techniques", CourseId = 5, CreatedAt = DateTime.Now },
                new Module { Title = "Module 4 - Time Blocking", CourseId = 5, CreatedAt = DateTime.Now },
                new Module { Title = "Module 5 - Dealing with Distractions", CourseId = 5, CreatedAt = DateTime.Now },
                new Module { Title = "Module 6 - Task Management Tools", CourseId = 5, CreatedAt = DateTime.Now },
                new Module { Title = "Module 7 - Pomodoro Technique", CourseId = 5, CreatedAt = DateTime.Now },
                new Module { Title = "Module 8 - Saying No Effectively", CourseId = 5, CreatedAt = DateTime.Now },
                new Module { Title = "Module 9 - Planning Your Day", CourseId = 5, CreatedAt = DateTime.Now },
                new Module { Title = "Module 10 - Habits for Productivity", CourseId = 5, CreatedAt = DateTime.Now }
            };

            return modules;


        }
    }
}
