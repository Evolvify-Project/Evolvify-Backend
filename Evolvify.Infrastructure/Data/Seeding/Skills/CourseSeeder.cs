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
                #region SkillId 1: Communication
                // Beginner: Communication
                new Course
                {
                    Title = "Introduction to Effective Communication",
                    Description = "Learn the basics of clear and concise communication",
                    Level = Level.Beginner,
                    SkillId = 1,
                    CreatedAt = DateTime.Now,
                    Duration = 80,
                    ImageUrl = "https://images.unsplash.com/photo-1516321318423-f06f85e504b3?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=80"
                },
                new Course
                {
                    Title = "Active Listening Skills",
                    Description = "Master the art of listening to improve conversations",
                    Level = Level.Beginner,
                    SkillId = 1,
                    CreatedAt = DateTime.Now,
                    Duration = 85,
                    ImageUrl = "https://images.unsplash.com/photo-1576267423429-569309b31e84?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=80"
                },
                new Course
                {
                    Title = "Non-Verbal Communication Basics",
                    Description = "Understand body language and facial expressions",
                    Level = Level.Beginner,
                    SkillId = 1,
                    CreatedAt = DateTime.Now,
                    Duration = 90,
                    ImageUrl = "https://images.unsplash.com/photo-1543269865-0a740d43b90c?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=80"
                },
                // Intermediate: Communication
                new Course
                {
                    Title = "Persuasive Communication Techniques",
                    Description = "Learn to influence and persuade effectively",
                    Level = Level.Intermediate,
                    SkillId = 1,
                    CreatedAt = DateTime.Now,
                    Duration = 100,
                    ImageUrl = "https://images.pexels.com/photos/3184297/pexels-photo-3184297.jpeg?auto=compress&cs=tinysrgb&w=800&h=800&dpr=1"
                },
                new Course
                {
                    Title = "Conflict Resolution Skills",
                    Description = "Resolve disputes through effective communication",
                    Level = Level.Intermediate,
                    SkillId = 1,
                    CreatedAt = DateTime.Now,
                    Duration = 105,
                    ImageUrl = "https://images.unsplash.com/photo-1522071820081-009f0129c71c?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=80"
                },
                new Course
                {
                    Title = "Cross-Cultural Communication",
                    Description = "Navigate communication in diverse settings",
                    Level = Level.Intermediate,
                    SkillId = 1,
                    CreatedAt = DateTime.Now,
                    Duration = 110,
                    ImageUrl = "https://images.unsplash.com/photo-1519085360753-af0119f7cbe7?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=80"
                },
                // Advanced: Communication
                new Course
                {
                    Title = "Mastering Strategic Communication",
                    Description = "Advanced techniques for high-stakes communication",
                    Level = Level.Advanced,
                    SkillId = 1,
                    CreatedAt = DateTime.Now,
                    Duration = 120,
                    ImageUrl = "https://images.unsplash.com/photo-1551836022-d5d88e9218df?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=80"
                },
                new Course
                {
                    Title = "Executive Presence in Communication",
                    Description = "Develop a commanding communication style",
                    Level = Level.Advanced,
                    SkillId = 1,
                    CreatedAt = DateTime.Now,
                    Duration = 125,
                    ImageUrl = "https://images.unsplash.com/photo-1516321497487-e288fb19713f?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=80"
                },
                new Course
                {
                    Title = "Crisis Communication Mastery",
                    Description = "Handle communication during critical situations",
                    Level = Level.Advanced,
                    SkillId = 1,
                    CreatedAt = DateTime.Now,
                    Duration = 130,
                    ImageUrl = "https://images.pexels.com/photos/3184306/pexels-photo-3184306.jpeg?auto=compress&cs=tinysrgb&w=800&h=800&dpr=1"
                },
                #endregion

                #region SkillId 2: Interviewing
                // Beginner: Interviewing
                new Course
                {
                    Title = "Ace the Interview",
                    Description = "Comprehensive interview preparation course",
                    Level = Level.Beginner,
                    SkillId = 2,
                    CreatedAt = DateTime.Now,
                    Duration = 90,
                    ImageUrl = "https://images.unsplash.com/photo-1556742044-3c52d6e88c62?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=80"
                },
                new Course
                {
                    Title = "Resume Building Basics",
                    Description = "Craft a standout resume for interviews",
                    Level = Level.Beginner,
                    SkillId = 2,
                    CreatedAt = DateTime.Now,
                    Duration = 85,
                    ImageUrl = "https://images.unsplash.com/photo-1516321318423-f06f85e504b3?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=80"
                },
                new Course
                {
                    Title = "Common Interview Questions",
                    Description = "Prepare answers for typical interview questions",
                    Level = Level.Beginner,
                    SkillId = 2,
                    CreatedAt = DateTime.Now,
                    Duration = 80,
                    ImageUrl = "https://images.unsplash.com/photo-1576267423429-569309b31e84?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=80"
                },
                // Intermediate: Interviewing
                new Course
                {
                    Title = "Behavioral Interview Mastery",
                    Description = "Excel in behavioral interview scenarios",
                    Level = Level.Intermediate,
                    SkillId = 2,
                    CreatedAt = DateTime.Now,
                    Duration = 100,
                    ImageUrl = "https://images.unsplash.com/photo-1543269865-0a740d43b90c?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=80"
                },
                new Course
                {
                    Title = "Technical Interview Prep",
                    Description = "Prepare for technical and role-specific interviews",
                    Level = Level.Intermediate,
                    SkillId = 2,
                    CreatedAt = DateTime.Now,
                    Duration = 105,
                    ImageUrl = "https://images.pexels.com/photos/1181675/pexels-photo-1181675.jpeg?auto=compress&cs=tinysrgb&w=800&h=800&dpr=1"
                },
                new Course
                {
                    Title = "Virtual Interview Skills",
                    Description = "Shine in online and remote interviews",
                    Level = Level.Intermediate,
                    SkillId = 2,
                    CreatedAt = DateTime.Now,
                    Duration = 110,
                    ImageUrl = "https://images.unsplash.com/photo-1519085360753-af0119f7cbe7?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=80"
                },
                // Advanced: Interviewing
                new Course
                {
                    Title = "Executive Interview Strategies",
                    Description = "Advanced techniques for senior-level interviews",
                    Level = Level.Advanced,
                    SkillId = 2,
                    CreatedAt = DateTime.Now,
                    Duration = 120,
                    ImageUrl = "https://images.unsplash.com/photo-1551836022-d5d88e9218df?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=80"
                },
                new Course
                {
                    Title = "Negotiation During Interviews",
                    Description = "Master salary and offer negotiations",
                    Level = Level.Advanced,
                    SkillId = 2,
                    CreatedAt = DateTime.Now,
                    Duration = 125,
                    ImageUrl = "https://images.unsplash.com/photo-1516321497487-e288fb19713f?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=80"
                },
                new Course
                {
                    Title = "Panel Interview Expertise",
                    Description = "Handle multi-interviewer scenarios with confidence",
                    Level = Level.Advanced,
                    SkillId = 2,
                    CreatedAt = DateTime.Now,
                    Duration = 130,
                    ImageUrl = "https://images.pexels.com/photos/3184325/pexels-photo-3184325.jpeg?auto=compress&cs=tinysrgb&w=800&h=800&dpr=1"
                },
                #endregion

                #region SkillId 3: Teamwork
                // Beginner: Teamwork
                new Course
                {
                    Title = "Teamwork Essentials",
                    Description = "Learn how to collaborate effectively with team members",
                    Level = Level.Beginner,
                    SkillId = 3,
                    CreatedAt = DateTime.Now,
                    Duration = 100,
                    ImageUrl = "https://images.unsplash.com/photo-1522071820081-009f0129c71c?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=80"
                },
                new Course
                {
                    Title = "Building Trust in Teams",
                    Description = "Foster trust and respect in team settings",
                    Level = Level.Beginner,
                    SkillId = 3,
                    CreatedAt = DateTime.Now,
                    Duration = 90,
                    ImageUrl = "https://images.unsplash.com/photo-1516321318423-f06f85e504b3?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=80"
                },
                new Course
                {
                    Title = "Team Communication Basics",
                    Description = "Improve communication within teams",
                    Level = Level.Beginner,
                    SkillId = 3,
                    CreatedAt = DateTime.Now,
                    Duration = 85,
                    ImageUrl = "https://images.unsplash.com/photo-1576267423429-569309b31e84?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=80"
                },
                // Intermediate: Teamwork
                new Course
                {
                    Title = "Collaborative Problem Solving",
                    Description = "Solve problems effectively as a team",
                    Level = Level.Intermediate,
                    SkillId = 3,
                    CreatedAt = DateTime.Now,
                    Duration = 105,
                    ImageUrl = "https://images.unsplash.com/photo-1543269865-0a740d43b90c?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=80"
                },
                new Course
                {
                    Title = "Managing Team Conflicts",
                    Description = "Handle and resolve team disputes",
                    Level = Level.Intermediate,
                    SkillId = 3,
                    CreatedAt = DateTime.Now,
                    Duration = 110,
                    ImageUrl = "https://images.pexels.com/photos/3184431/pexels-photo-3184431.jpeg?auto=compress&cs=tinysrgb&w=800&h=800&dpr=1"
                },
                new Course
                {
                    Title = "Remote Team Collaboration",
                    Description = "Work effectively in distributed teams",
                    Level = Level.Intermediate,
                    SkillId = 3,
                    CreatedAt = DateTime.Now,
                    Duration = 100,
                    ImageUrl = "https://images.unsplash.com/photo-1519085360753-af0119f7cbe7?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=80"
                },
                // Advanced: Teamwork
                new Course
                {
                    Title = "Leading High-Performance Teams",
                    Description = "Drive exceptional team performance",
                    Level = Level.Advanced,
                    SkillId = 3,
                    CreatedAt = DateTime.Now,
                    Duration = 125,
                    ImageUrl = "https://images.unsplash.com/photo-1551836022-d5d88e9218df?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=80"
                },
                new Course
                {
                    Title = "Team Innovation Strategies",
                    Description = "Foster creativity and innovation in teams",
                    Level = Level.Advanced,
                    SkillId = 3,
                    CreatedAt = DateTime.Now,
                    Duration = 130,
                    ImageUrl = "https://images.unsplash.com/photo-1516321497487-e288fb19713f?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=80"
                },
                new Course
                {
                    Title = "Cross-Functional Team Leadership",
                    Description = "Lead diverse teams across departments",
                    Level = Level.Advanced,
                    SkillId = 3,
                    CreatedAt = DateTime.Now,
                    Duration = 120,
                    ImageUrl = "https://images.pexels.com/photos/3184291/pexels-photo-3184291.jpeg?auto=compress&cs=tinysrgb&w=800&h=800&dpr=1"
                },
                #endregion

                #region SkillId 4: Presentation
                // Beginner: Presentation
                new Course
                {
                    Title = "Presentation Pro",
                    Description = "Craft and deliver compelling presentations",
                    Level = Level.Beginner,
                    SkillId = 4,
                    CreatedAt = DateTime.Now,
                    Duration = 110,
                    ImageUrl = "https://images.unsplash.com/photo-1505373877841-8d25f7d46678?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=80"
                },
                new Course
                {
                    Title = "Creating Engaging Slides",
                    Description = "Design visually appealing presentation slides",
                    Level = Level.Beginner,
                    SkillId = 4,
                    CreatedAt = DateTime.Now,
                    Duration = 90,
                    ImageUrl = "https://images.unsplash.com/photo-1516321318423-f06f85e504b3?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=80"
                },
                new Course
                {
                    Title = "Public Speaking Basics",
                    Description = "Overcome fear and speak confidently",
                    Level = Level.Beginner,
                    SkillId = 4,
                    CreatedAt = DateTime.Now,
                    Duration = 85,
                    ImageUrl = "https://images.unsplash.com/photo-1576267423429-569309b31e84?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=80"
                },
                // Intermediate: Presentation
                new Course
                {
                    Title = "Storytelling in Presentations",
                    Description = "Use storytelling to captivate audiences",
                    Level = Level.Intermediate,
                    SkillId = 4,
                    CreatedAt = DateTime.Now,
                    Duration = 105,
                    ImageUrl = "https://images.unsplash.com/photo-1543269865-0a740d43b90c?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=80"
                },
                new Course
                {
                    Title = "Data Visualization for Presentations",
                    Description = "Present data clearly and effectively",
                    Level = Level.Intermediate,
                    SkillId = 4,
                    CreatedAt = DateTime.Now,
                    Duration = 100,
                    ImageUrl = "https://images.pexels.com/photos/669615/pexels-photo-669615.jpeg?auto=compress&cs=tinysrgb&w=800&h=800&dpr=1"
                },
                new Course
                {
                    Title = "Interactive Presentations",
                    Description = "Engage audiences with interactive techniques",
                    Level = Level.Intermediate,
                    SkillId = 4,
                    CreatedAt = DateTime.Now,
                    Duration = 110,
                    ImageUrl = "https://images.unsplash.com/photo-1519085360753-af0119f7cbe7?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=80"
                },
                // Advanced: Presentation
                new Course
                {
                    Title = "Keynote Mastery",
                    Description = "Deliver world-class keynote presentations",
                    Level = Level.Advanced,
                    SkillId = 4,
                    CreatedAt = DateTime.Now,
                    Duration = 130,
                    ImageUrl = "https://images.unsplash.com/photo-1551836022-d5d88e9218df?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=80"
                },
                new Course
                {
                    Title = "Persuasive Pitching",
                    Description = "Craft pitches that win over stakeholders",
                    Level = Level.Advanced,
                    SkillId = 4,
                    CreatedAt = DateTime.Now,
                    Duration = 125,
                    ImageUrl = "https://images.unsplash.com/photo-1516321497487-e288fb19713f?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=80"
                },
                new Course
                {
                    Title = "Virtual Presentation Excellence",
                    Description = "Master online and hybrid presentations",
                    Level = Level.Advanced,
                    SkillId = 4,
                    CreatedAt = DateTime.Now,
                    Duration = 120,
                    ImageUrl = "https://images.pexels.com/photos/3183165/pexels-photo-3183165.jpeg?auto=compress&cs=tinysrgb&w=800&h=800&dpr=1"
                },
                #endregion

                #region SkillId 5: Time Management
                // Beginner: Time Management
                new Course
                {
                    Title = "Time Management 101",
                    Description = "Manage your time and tasks efficiently",
                    Level = Level.Beginner,
                    SkillId = 5,
                    CreatedAt = DateTime.Now,
                    Duration = 80,
                    ImageUrl = "https://images.unsplash.com/photo-1506784983877-45594efa4cbe?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=80"
                },
                new Course
                {
                    Title = "Prioritization Techniques",
                    Description = "Learn to prioritize tasks effectively",
                    Level = Level.Beginner,
                    SkillId = 5,
                    CreatedAt = DateTime.Now,
                    Duration = 85,
                    ImageUrl = "https://images.unsplash.com/photo-1516321318423-f06f85e504b3?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=80"
                },
                new Course
                {
                    Title = "Goal Setting Basics",
                    Description = "Set and achieve personal and professional goals",
                    Level = Level.Beginner,
                    SkillId = 5,
                    CreatedAt = DateTime.Now,
                    Duration = 90,
                    ImageUrl = "https://images.unsplash.com/photo-1576267423429-569309b31e84?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=80"
                },
                // Intermediate: Time Management
                new Course
                {
                    Title = "Advanced Task Management",
                    Description = "Optimize workflows for productivity",
                    Level = Level.Intermediate,
                    SkillId = 5,
                    CreatedAt = DateTime.Now,
                    Duration = 100,
                    ImageUrl = "https://images.unsplash.com/photo-1543269865-0a740d43b90c?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=80"
                },
                new Course
                {
                    Title = "Delegation Skills",
                    Description = "Delegate tasks to maximize efficiency",
                    Level = Level.Intermediate,
                    SkillId = 5,
                    CreatedAt = DateTime.Now,
                    Duration = 105,
                    ImageUrl = "https://images.pexels.com/photos/3184418/pexels-photo-3184418.jpeg?auto=compress&cs=tinysrgb&w=800&h=800&dpr=1"
                },
                new Course
                {
                    Title = "Managing Distractions",
                    Description = "Stay focused in a busy environment",
                    Level = Level.Intermediate,
                    SkillId = 5,
                    CreatedAt = DateTime.Now,
                    Duration = 110,
                    ImageUrl = "https://images.unsplash.com/photo-1519085360753-af0119f7cbe7?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=80"
                },
                // Advanced: Time Management
                new Course
                {
                    Title = "Strategic Time Management",
                    Description = "Master time allocation for long-term success",
                    Level = Level.Advanced,
                    SkillId = 5,
                    CreatedAt = DateTime.Now,
                    Duration = 120,
                    ImageUrl = "https://images.unsplash.com/photo-1551836022-d5d88e9218df?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=80"
                },
                new Course
                {
                    Title = "Productivity Systems Design",
                    Description = "Create custom productivity frameworks",
                    Level = Level.Advanced,
                    SkillId = 5,
                    CreatedAt = DateTime.Now,
                    Duration = 125,
                    ImageUrl = "https://images.unsplash.com/photo-1516321497487-e288fb19713f?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=80"
                },
                new Course
                {
                    Title = "Time Management for Leaders",
                    Description = "Optimize time for leadership responsibilities",
                    Level = Level.Advanced,
                    SkillId = 5,
                    CreatedAt = DateTime.Now,
                    Duration = 130,
                    ImageUrl = "https://images.pexels.com/photos/3184287/pexels-photo-3184287.jpeg?auto=compress&cs=tinysrgb&w=800&h=800&dpr=1"
                }
                #endregion
            };

            return courses;
        }
    }
}