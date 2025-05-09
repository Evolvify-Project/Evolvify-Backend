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
                #region SkillId 1: Communication (Courses 1-9)
                // Course 1: Introduction to Effective Communication (Beginner, CourseId 1)
                new Module { Title = "Module 1 - Communication Fundamentals", CourseId = 1, CreatedAt = DateTime.Now },
                new Module { Title = "Module 2 - Clarity in Speech", CourseId = 1, CreatedAt = DateTime.Now },
                new Module { Title = "Module 3 - Basic Listening Skills", CourseId = 1, CreatedAt = DateTime.Now },
                new Module { Title = "Module 4 - Understanding Tone", CourseId = 1, CreatedAt = DateTime.Now },
                new Module { Title = "Module 5 - Asking Questions", CourseId = 1, CreatedAt = DateTime.Now },
                new Module { Title = "Module 6 - Building Rapport", CourseId = 1, CreatedAt = DateTime.Now },
                new Module { Title = "Module 7 - Overcoming Shyness", CourseId = 1, CreatedAt = DateTime.Now },
                new Module { Title = "Module 8 - Basic Feedback Skills", CourseId = 1, CreatedAt = DateTime.Now },
                new Module { Title = "Module 9 - Communication Barriers", CourseId = 1, CreatedAt = DateTime.Now },
                new Module { Title = "Module 10 - Practice Scenarios", CourseId = 1, CreatedAt = DateTime.Now },

                // Course 2: Active Listening Skills (Beginner, CourseId 2)
                new Module { Title = "Module 1 - What is Active Listening?", CourseId = 2, CreatedAt = DateTime.Now },
                new Module { Title = "Module 2 - Ear on, Distractions Off", CourseId = 2, CreatedAt = DateTime.Now },
                new Module { Title = "Module 3 - Empathetic Responses", CourseId = 2, CreatedAt = DateTime.Now },
                new Module { Title = "Module 4 - Paraphrasing Techniques", CourseId = 2, CreatedAt = DateTime.Now },
                new Module { Title = "Module 5 - Non-Verbal Listening Cues", CourseId = 2, CreatedAt = DateTime.Now },
                new Module { Title = "Module 6 - Asking Clarifying Questions", CourseId = 2, CreatedAt = DateTime.Now },
                new Module { Title = "Module 7 - Avoiding Interruptions", CourseId = 2, CreatedAt = DateTime.Now },
                new Module { Title = "Module 8 - Listening in Groups", CourseId = 2, CreatedAt = DateTime.Now },
                new Module { Title = "Module 9 - Overcoming Listening Barriers", CourseId = 2, CreatedAt = DateTime.Now },
                new Module { Title = "Module 10 - Listening Practice", CourseId = 2, CreatedAt = DateTime.Now },

                // Course 4: Persuasive Communication Techniques (Intermediate, CourseId 4)
                new Module { Title = "Module 1 - Principles of Persuasion", CourseId = 4, CreatedAt = DateTime.Now },
                new Module { Title = "Module 2 - Understanding Your Audience", CourseId = 4, CreatedAt = DateTime.Now },
                new Module { Title = "Module 3 - Crafting Compelling Arguments", CourseId = 4, CreatedAt = DateTime.Now },
                new Module { Title = "Module 4 - Emotional Appeals", CourseId = 4, CreatedAt = DateTime.Now },
                new Module { Title = "Module 5 - Logical Reasoning", CourseId = 4, CreatedAt = DateTime.Now },
                new Module { Title = "Module 6 - Storytelling for Persuasion", CourseId = 4, CreatedAt = DateTime.Now },
                new Module { Title = "Module 7 - Handling Objections", CourseId = 4, CreatedAt = DateTime.Now },
                new Module { Title = "Module 8 - Ethical Persuasion", CourseId = 4, CreatedAt = DateTime.Now },
                new Module { Title = "Module 9 - Persuasive Body Language", CourseId = 4, CreatedAt = DateTime.Now },
                new Module { Title = "Module 10 - Persuasion Practice", CourseId = 4, CreatedAt = DateTime.Now },

                // Course 5: Conflict Resolution Skills (Intermediate, CourseId 5)
                new Module { Title = "Module 1 - Understanding Conflict", CourseId = 5, CreatedAt = DateTime.Now },
                new Module { Title = "Module 2 - Conflict Styles", CourseId = 5, CreatedAt = DateTime.Now },
                new Module { Title = "Module 3 - Active Listening in Conflict", CourseId = 5, CreatedAt = DateTime.Now },
                new Module { Title = "Module 4 - Managing Emotions", CourseId = 5, CreatedAt = DateTime.Now },
                new Module { Title = "Module 5 - Negotiation Basics", CourseId = 5, CreatedAt = DateTime.Now },
                new Module { Title = "Module 6 - Finding Common Ground", CourseId = 5, CreatedAt = DateTime.Now },
                new Module { Title = "Module 7 - Mediation Techniques", CourseId = 5, CreatedAt = DateTime.Now },
                new Module { Title = "Module 8 - Resolving Misunderstandings", CourseId = 5, CreatedAt = DateTime.Now },
                new Module { Title = "Module 9 - Post-Conflict Follow-Up", CourseId = 5, CreatedAt = DateTime.Now },
                new Module { Title = "Module 10 - Conflict Resolution Practice", CourseId = 5, CreatedAt = DateTime.Now },

                // Course 7: Mastering Strategic Communication (Advanced, CourseId 7)
                new Module { Title = "Module 1 - Strategic Communication Overview", CourseId = 7, CreatedAt = DateTime.Now },
                new Module { Title = "Module 2 - Aligning Messages with Goals", CourseId = 7, CreatedAt = DateTime.Now },
                new Module { Title = "Module 3 - High-Stakes Audience Analysis", CourseId = 7, CreatedAt = DateTime.Now },
                new Module { Title = "Module 4 - Crafting Key Messages", CourseId = 7, CreatedAt = DateTime.Now },
                new Module { Title = "Module 5 - Advanced Persuasion Techniques", CourseId = 7, CreatedAt = DateTime.Now },
                new Module { Title = "Module 6 - Managing Stakeholder Expectations", CourseId = 7, CreatedAt = DateTime.Now },
                new Module { Title = "Module 7 - Crisis Communication Strategies", CourseId = 7, CreatedAt = DateTime.Now },
                new Module { Title = "Module 8 - Executive Delivery Skills", CourseId = 7, CreatedAt = DateTime.Now },
                new Module { Title = "Module 9 - Measuring Communication Impact", CourseId = 7, CreatedAt = DateTime.Now },
                new Module { Title = "Module 10 - Strategic Communication Scenarios", CourseId = 7, CreatedAt = DateTime.Now },

                // Course 8: Executive Presence in Communication (Advanced, CourseId 8)
                new Module { Title = "Module 1 - Defining Executive Presence", CourseId = 8, CreatedAt = DateTime.Now },
                new Module { Title = "Module 2 - Building Credibility", CourseId = 8, CreatedAt = DateTime.Now },
                new Module { Title = "Module 3 - Commanding Attention", CourseId = 8, CreatedAt = DateTime.Now },
                new Module { Title = "Module 4 - Confident Body Language", CourseId = 8, CreatedAt = DateTime.Now },
                new Module { Title = "Module 5 - Vocal Authority", CourseId = 8, CreatedAt = DateTime.Now },
                new Module { Title = "Module 6 - Emotional Intelligence in Leadership", CourseId = 8, CreatedAt = DateTime.Now },
                new Module { Title = "Module 7 - Adapting to Audiences", CourseId = 8, CreatedAt = DateTime.Now },
                new Module { Title = "Module 8 - Handling High-Pressure Situations", CourseId = 8, CreatedAt = DateTime.Now },
                new Module { Title = "Module 9 - Storytelling for Impact", CourseId = 8, CreatedAt = DateTime.Now },
                new Module { Title = "Module 10 - Executive Presence Practice", CourseId = 8, CreatedAt = DateTime.Now },
                #endregion

                #region SkillId 2: Interviewing (Courses 10-18)
                // Course 10: Ace the Interview (Beginner, CourseId 10)
                new Module { Title = "Module 1 - Interview Preparation Basics", CourseId = 10, CreatedAt = DateTime.Now },
                new Module { Title = "Module 2 - Understanding Job Descriptions", CourseId = 10, CreatedAt = DateTime.Now },
                new Module { Title = "Module 3 - Crafting Your Elevator Pitch", CourseId = 10, CreatedAt = DateTime.Now },
                new Module { Title = "Module 4 - Common Interview Questions", CourseId = 10, CreatedAt = DateTime.Now },
                new Module { Title = "Module 5 - Dressing Appropriately", CourseId = 10, CreatedAt = DateTime.Now },
                new Module { Title = "Module 6 - Body Language Basics", CourseId = 10, CreatedAt = DateTime.Now },
                new Module { Title = "Module 7 - First Impressions", CourseId = 10, CreatedAt = DateTime.Now },
                new Module { Title = "Module 8 - Mock Interview Practice", CourseId = 10, CreatedAt = DateTime.Now },
                new Module { Title = "Module 9 - Handling Nerves", CourseId = 10, CreatedAt = DateTime.Now },
                new Module { Title = "Module 10 - Post-Interview Follow-Up", CourseId = 10, CreatedAt = DateTime.Now },

                // Course 11: Resume Building Basics (Beginner, CourseId 11)
                new Module { Title = "Module 1 - Resume Fundamentals", CourseId = 11, CreatedAt = DateTime.Now },
                new Module { Title = "Module 2 - Choosing the Right Format", CourseId = 11, CreatedAt = DateTime.Now },
                new Module { Title = "Module 3 - Highlighting Skills", CourseId = 11, CreatedAt = DateTime.Now },
                new Module { Title = "Module 4 - Writing Strong Bullet Points", CourseId = 11, CreatedAt = DateTime.Now },
                new Module { Title = "Module 5 - Tailoring Your Resume", CourseId = 11, CreatedAt = DateTime.Now },
                new Module { Title = "Module 6 - Including Achievements", CourseId = 11, CreatedAt = DateTime.Now },
                new Module { Title = "Module 7 - Avoiding Common Mistakes", CourseId = 11, CreatedAt = DateTime.Now },
                new Module { Title = "Module 8 - Cover Letter Basics", CourseId = 11, CreatedAt = DateTime.Now },
                new Module { Title = "Module 9 - Resume Design Tips", CourseId = 11, CreatedAt = DateTime.Now },
                new Module { Title = "Module 10 - Resume Review Practice", CourseId = 11, CreatedAt = DateTime.Now },

                // Course 13: Behavioral Interview Mastery (Intermediate, CourseId 13)
                new Module { Title = "Module 1 - Behavioral Interview Overview", CourseId = 13, CreatedAt = DateTime.Now },
                new Module { Title = "Module 2 - STAR Method Explained", CourseId = 13, CreatedAt = DateTime.Now },
                new Module { Title = "Module 3 - Identifying Key Competencies", CourseId = 13, CreatedAt = DateTime.Now },
                new Module { Title = "Module 4 - Crafting STAR Stories", CourseId = 13, CreatedAt = DateTime.Now },
                new Module { Title = "Module 5 - Common Behavioral Questions", CourseId = 13, CreatedAt = DateTime.Now },
                new Module { Title = "Module 6 - Handling Unexpected Questions", CourseId = 13, CreatedAt = DateTime.Now },
                new Module { Title = "Module 7 - Practicing Concise Answers", CourseId = 13, CreatedAt = DateTime.Now },
                new Module { Title = "Module 8 - Mock Behavioral Interviews", CourseId = 13, CreatedAt = DateTime.Now },
                new Module { Title = "Module 9 - Feedback and Improvement", CourseId = 13, CreatedAt = DateTime.Now },
                new Module { Title = "Module 10 - Advanced STAR Techniques", CourseId = 13, CreatedAt = DateTime.Now },

                // Course 14: Technical Interview Prep (Intermediate, CourseId 14)
                new Module { Title = "Module 1 - Technical Interview Basics", CourseId = 14, CreatedAt = DateTime.Now },
                new Module { Title = "Module 2 - Understanding Role Requirements", CourseId = 14, CreatedAt = DateTime.Now },
                new Module { Title = "Module 3 - Problem-Solving Strategies", CourseId = 14, CreatedAt = DateTime.Now },
                new Module { Title = "Module 4 - Coding Interview Tips", CourseId = 14, CreatedAt = DateTime.Now },
                new Module { Title = "Module 5 - Whiteboard Practice", CourseId = 14, CreatedAt = DateTime.Now },
                new Module { Title = "Module 6 - System Design Basics", CourseId = 14, CreatedAt = DateTime.Now },
                new Module { Title = "Module 7 - Common Technical Questions", CourseId = 14, CreatedAt = DateTime.Now },
                new Module { Title = "Module 8 - Mock Technical Interviews", CourseId = 14, CreatedAt = DateTime.Now },
                new Module { Title = "Module 9 - Time Management in Interviews", CourseId = 14, CreatedAt = DateTime.Now },
                new Module { Title = "Module 10 - Post-Interview Analysis", CourseId = 14, CreatedAt = DateTime.Now },

                // Course 16: Executive Interview Strategies (Advanced, CourseId 16)
                new Module { Title = "Module 1 - Executive Interview Overview", CourseId = 16, CreatedAt = DateTime.Now },
                new Module { Title = "Module 2 - Aligning with Company Vision", CourseId = 16, CreatedAt = DateTime.Now },
                new Module { Title = "Module 3 - Showcasing Leadership", CourseId = 16, CreatedAt = DateTime.Now },
                new Module { Title = "Module 4 - Strategic Question Handling", CourseId = 16, CreatedAt = DateTime.Now },
                new Module { Title = "Module 5 - Demonstrating Impact", CourseId = 16, CreatedAt = DateTime.Now },
                new Module { Title = "Module 6 - Navigating Panel Interviews", CourseId = 16, CreatedAt = DateTime.Now },
                new Module { Title = "Module 7 - Salary Negotiation Tactics", CourseId = 16, CreatedAt = DateTime.Now },
                new Module { Title = "Module 8 - Executive Presence", CourseId = 16, CreatedAt = DateTime.Now },
                new Module { Title = "Module 9 - Mock Executive Interviews", CourseId = 16, CreatedAt = DateTime.Now },
                new Module { Title = "Module 10 - Building Long-Term Relationships", CourseId = 16, CreatedAt = DateTime.Now },

                // Course 17: Negotiation During Interviews (Advanced, CourseId 17)
                new Module { Title = "Module 1 - Negotiation Fundamentals", CourseId = 17, CreatedAt = DateTime.Now },
                new Module { Title = "Module 2 - Understanding Your Value", CourseId = 17, CreatedAt = DateTime.Now },
                new Module { Title = "Module 3 - Researching Market Rates", CourseId = 17, CreatedAt = DateTime.Now },
                new Module { Title = "Module 4 - Timing Your Negotiation", CourseId = 17, CreatedAt = DateTime.Now },
                new Module { Title = "Module 5 - Negotiating Salary", CourseId = 17, CreatedAt = DateTime.Now },
                new Module { Title = "Module 6 - Negotiating Benefits", CourseId = 17, CreatedAt = DateTime.Now },
                new Module { Title = "Module 7 - Handling Counteroffers", CourseId = 17, CreatedAt = DateTime.Now },
                new Module { Title = "Module 8 - Ethical Negotiation", CourseId = 17, CreatedAt = DateTime.Now },
                new Module { Title = "Module 9 - Practice Negotiation Scenarios", CourseId = 17, CreatedAt = DateTime.Now },
                new Module { Title = "Module 10 - Closing the Deal", CourseId = 17, CreatedAt = DateTime.Now },
                #endregion

                #region SkillId 3: Teamwork (Courses 19-27)
                // Course 19: Teamwork Essentials (Beginner, CourseId 19)
                new Module { Title = "Module 1 - Introduction to Teamwork", CourseId = 19, CreatedAt = DateTime.Now },
                new Module { Title = "Module 2 - Roles in a Team", CourseId = 19, CreatedAt = DateTime.Now },
                new Module { Title = "Module 3 - Basic Team Communication", CourseId = 19, CreatedAt = DateTime.Now },
                new Module { Title = "Module 4 - Building Trust", CourseId = 19, CreatedAt = DateTime.Now },
                new Module { Title = "Module 5 - Respecting Diversity", CourseId = 19, CreatedAt = DateTime.Now },
                new Module { Title = "Module 6 - Collaborative Tools", CourseId = 19, CreatedAt = DateTime.Now },
                new Module { Title = "Module 7 - Contributing Effectively", CourseId = 19, CreatedAt = DateTime.Now },
                new Module { Title = "Module 8 - Giving Feedback", CourseId = 19, CreatedAt = DateTime.Now },
                new Module { Title = "Module 9 - Teamwork Challenges", CourseId = 19, CreatedAt = DateTime.Now },
                new Module { Title = "Module 10 - Teamwork Practice", CourseId = 19, CreatedAt = DateTime.Now },

                // Course 20: Building Trust in Teams (Beginner, CourseId 20)
                new Module { Title = "Module 1 - Trust Fundamentals", CourseId = 20, CreatedAt = DateTime.Now },
                new Module { Title = "Module 2 - Reliability in Teams", CourseId = 20, CreatedAt = DateTime.Now },
                new Module { Title = "Module 3 - Open Communication", CourseId = 20, CreatedAt = DateTime.Now },
                new Module { Title = "Module 4 - Showing Respect", CourseId = 20, CreatedAt = DateTime.Now },
                new Module { Title = "Module 5 - Consistency in Actions", CourseId = 20, CreatedAt = DateTime.Now },
                new Module { Title = "Module 6 - Handling Mistakes", CourseId = 20, CreatedAt = DateTime.Now },
                new Module { Title = "Module 7 - Building Rapport", CourseId = 20, CreatedAt = DateTime.Now },
                new Module { Title = "Module 8 - Trust-Building Exercises", CourseId = 20, CreatedAt = DateTime.Now },
                new Module { Title = "Module 9 - Maintaining Trust", CourseId = 20, CreatedAt = DateTime.Now },
                new Module { Title = "Module 10 - Trust Practice Scenarios", CourseId = 20, CreatedAt = DateTime.Now },

                // Course 22: Collaborative Problem Solving (Intermediate, CourseId 22)
                new Module { Title = "Module 1 - Problem-Solving Overview", CourseId = 22, CreatedAt = DateTime.Now },
                new Module { Title = "Module 2 - Defining the Problem", CourseId = 22, CreatedAt = DateTime.Now },
                new Module { Title = "Module 3 - Brainstorming as a Team", CourseId = 22, CreatedAt = DateTime.Now },
                new Module { Title = "Module 4 - Evaluating Solutions", CourseId = 22, CreatedAt = DateTime.Now },
                new Module { Title = "Module 5 - Decision-Making Strategies", CourseId = 22, CreatedAt = DateTime.Now },
                new Module { Title = "Module 6 - Implementing Solutions", CourseId = 22, CreatedAt = DateTime.Now },
                new Module { Title = "Module 7 - Team Communication in Problem Solving", CourseId = 22, CreatedAt = DateTime.Now },
                new Module { Title = "Module 8 - Handling Conflicts", CourseId = 22, CreatedAt = DateTime.Now },
                new Module { Title = "Module 9 - Measuring Success", CourseId = 22, CreatedAt = DateTime.Now },
                new Module { Title = "Module 10 - Problem-Solving Practice", CourseId = 22, CreatedAt = DateTime.Now },

                // Course 23: Managing Team Conflicts (Intermediate, CourseId 23)
                new Module { Title = "Module 1 - Conflict in Teams", CourseId = 23, CreatedAt = DateTime.Now },
                new Module { Title = "Module 2 - Identifying Conflict Sources", CourseId = 23, CreatedAt = DateTime.Now },
                new Module { Title = "Module 3 - Active Listening in Conflicts", CourseId = 23, CreatedAt = DateTime.Now },
                new Module { Title = "Module 4 - Emotional Regulation", CourseId = 23, CreatedAt = DateTime.Now },
                new Module { Title = "Module 5 - Negotiation Techniques", CourseId = 23, CreatedAt = DateTime.Now },
                new Module { Title = "Module 6 - Mediating Disputes", CourseId = 23, CreatedAt = DateTime.Now },
                new Module { Title = "Module 7 - Building Consensus", CourseId = 23, CreatedAt = DateTime.Now },
                new Module { Title = "Module 8 - Preventing Future Conflicts", CourseId = 23, CreatedAt = DateTime.Now },
                new Module { Title = "Module 9 - Post-Conflict Team Building", CourseId = 23, CreatedAt = DateTime.Now },
                new Module { Title = "Module 10 - Conflict Management Practice", CourseId = 23, CreatedAt = DateTime.Now },

                // Course 25: Leading High-Performance Teams (Advanced, CourseId 25)
                new Module { Title = "Module 1 - High-Performance Team Traits", CourseId = 25, CreatedAt = DateTime.Now },
                new Module { Title = "Module 2 - Setting Team Vision", CourseId = 25, CreatedAt = DateTime.Now },
                new Module { Title = "Module 3 - Aligning Goals", CourseId = 25, CreatedAt = DateTime.Now },
                new Module { Title = "Module 4 - Motivating Team Members", CourseId = 25, CreatedAt = DateTime.Now },
                new Module { Title = "Module 5 - Delegating Effectively", CourseId = 25, CreatedAt = DateTime.Now },
                new Module { Title = "Module 6 - Fostering Innovation", CourseId = 25, CreatedAt = DateTime.Now },
                new Module { Title = "Module 7 - Performance Monitoring", CourseId = 25, CreatedAt = DateTime.Now },
                new Module { Title = "Module 8 - Providing Feedback", CourseId = 25, CreatedAt = DateTime.Now },
                new Module { Title = "Module 9 - Handling Underperformance", CourseId = 25, CreatedAt = DateTime.Now },
                new Module { Title = "Module 10 - Leading Team Success", CourseId = 25, CreatedAt = DateTime.Now },

                // Course 26: Team Innovation Strategies (Advanced, CourseId 26)
                new Module { Title = "Module 1 - Innovation in Teams", CourseId = 26, CreatedAt = DateTime.Now },
                new Module { Title = "Module 2 - Creating a Creative Culture", CourseId = 26, CreatedAt = DateTime.Now },
                new Module { Title = "Module 3 - Brainstorming Techniques", CourseId = 26, CreatedAt = DateTime.Now },
                new Module { Title = "Module 4 - Encouraging Risk-Taking", CourseId = 26, CreatedAt = DateTime.Now },
                new Module { Title = "Module 5 - Leveraging Diversity", CourseId = 26, CreatedAt = DateTime.Now },
                new Module { Title = "Module 6 - Prototyping Ideas", CourseId = 26, CreatedAt = DateTime.Now },
                new Module { Title = "Module 7 - Collaboration Tools for Innovation", CourseId = 26, CreatedAt = DateTime.Now },
                new Module { Title = "Module 8 - Measuring Innovation Impact", CourseId = 26, CreatedAt = DateTime.Now },
                new Module { Title = "Module 9 - Overcoming Resistance", CourseId = 26, CreatedAt = DateTime.Now },
                new Module { Title = "Module 10 - Innovation Practice", CourseId = 26, CreatedAt = DateTime.Now },
                #endregion

                #region SkillId 4: Presentation (Courses 28-36)
                // Course 28: Presentation Pro (Beginner, CourseId 28)
                new Module { Title = "Module 1 - Presentation Basics", CourseId = 28, CreatedAt = DateTime.Now },
                new Module { Title = "Module 2 - Understanding Your Audience", CourseId = 28, CreatedAt = DateTime.Now },
                new Module { Title = "Module 3 - Structuring a Presentation", CourseId = 28, CreatedAt = DateTime.Now },
                new Module { Title = "Module 4 - Basic Slide Design", CourseId = 28, CreatedAt = DateTime.Now },
                new Module { Title = "Module 5 - Overcoming Stage Fright", CourseId = 28, CreatedAt = DateTime.Now },
                new Module { Title = "Module 6 - Voice and Tone Basics", CourseId = 28, CreatedAt = DateTime.Now },
                new Module { Title = "Module 7 - Body Language Tips", CourseId = 28, CreatedAt = DateTime.Now },
                new Module { Title = "Module 8 - Visual Aids Introduction", CourseId = 28, CreatedAt = DateTime.Now },
                new Module { Title = "Module 9 - Practice Presentations", CourseId = 28, CreatedAt = DateTime.Now },
                new Module { Title = "Module 10 - Presentation Feedback", CourseId = 28, CreatedAt = DateTime.Now },

                // Course 29: Creating Engaging Slides (Beginner, CourseId 29)
                new Module { Title = "Module 1 - Slide Design Fundamentals", CourseId = 29, CreatedAt = DateTime.Now },
                new Module { Title = "Module 2 - Choosing Fonts and Colors", CourseId = 29, CreatedAt = DateTime.Now },
                new Module { Title = "Module 3 - Using Templates", CourseId = 29, CreatedAt = DateTime.Now },
                new Module { Title = "Module 4 - Visual Hierarchy", CourseId = 29, CreatedAt = DateTime.Now },
                new Module { Title = "Module 5 - Incorporating Images", CourseId = 29, CreatedAt = DateTime.Now },
                new Module { Title = "Module 6 - Avoiding Clutter", CourseId = 29, CreatedAt = DateTime.Now },
                new Module { Title = "Module 7 - Animation Basics", CourseId = 29, CreatedAt = DateTime.Now },
                new Module { Title = "Module 8 - Design Tools Overview", CourseId = 29, CreatedAt = DateTime.Now },
                new Module { Title = "Module 9 - Slide Design Practice", CourseId = 29, CreatedAt = DateTime.Now },
                new Module { Title = "Module 10 - Reviewing Slide Decks", CourseId = 29, CreatedAt = DateTime.Now },

                // Course 31: Storytelling in Presentations (Intermediate, CourseId 31)
                new Module { Title = "Module 1 - Storytelling Fundamentals", CourseId = 31, CreatedAt = DateTime.Now },
                new Module { Title = "Module 2 - Narrative Structures", CourseId = 31, CreatedAt = DateTime.Now },
                new Module { Title = "Module 3 - Creating Emotional Impact", CourseId = 31, CreatedAt = DateTime.Now },
                new Module { Title = "Module 4 - Building a Story Arc", CourseId = 31, CreatedAt = DateTime.Now },
                new Module { Title = "Module 5 - Using Anecdotes", CourseId = 31, CreatedAt = DateTime.Now },
                new Module { Title = "Module 6 - Visual Storytelling", CourseId = 31, CreatedAt = DateTime.Now },
                new Module { Title = "Module 7 - Engaging Your Audience", CourseId = 31, CreatedAt = DateTime.Now },
                new Module { Title = "Module 8 - Pacing and Delivery", CourseId = 31, CreatedAt = DateTime.Now },
                new Module { Title = "Module 9 - Storytelling Practice", CourseId = 31, CreatedAt = DateTime.Now },
                new Module { Title = "Module 10 - Story Feedback", CourseId = 31, CreatedAt = DateTime.Now },

                // Course 32: Data Visualization for Presentations (Intermediate, CourseId 32)
                new Module { Title = "Module 1 - Data Visualization Basics", CourseId = 32, CreatedAt = DateTime.Now },
                new Module { Title = "Module 2 - Choosing the Right Chart", CourseId = 32, CreatedAt = DateTime.Now },
                new Module { Title = "Module 3 - Simplifying Data", CourseId = 32, CreatedAt = DateTime.Now },
                new Module { Title = "Module 4 - Design Principles for Data", CourseId = 32, CreatedAt = DateTime.Now },
                new Module { Title = "Module 5 - Using Colors Effectively", CourseId = 32, CreatedAt = DateTime.Now },
                new Module { Title = "Module 6 - Storytelling with Data", CourseId = 32, CreatedAt = DateTime.Now },
                new Module { Title = "Module 7 - Tools for Visualization", CourseId = 32, CreatedAt = DateTime.Now },
                new Module { Title = "Module 8 - Avoiding Misleading Visuals", CourseId = 32, CreatedAt = DateTime.Now },
                new Module { Title = "Module 9 - Data Visualization Practice", CourseId = 32, CreatedAt = DateTime.Now },
                new Module { Title = "Module 10 - Reviewing Visuals", CourseId = 32, CreatedAt = DateTime.Now },

                // Course 34: Keynote Mastery (Advanced, CourseId 34)
                new Module { Title = "Module 1 - Keynote Presentation Overview", CourseId = 34, CreatedAt = DateTime.Now },
                new Module { Title = "Module 2 - Crafting a Compelling Narrative", CourseId = 34, CreatedAt = DateTime.Now },
                new Module { Title = "Module 3 - Advanced Slide Design", CourseId = 34, CreatedAt = DateTime.Now },
                new Module { Title = "Module 4 - High-Impact Visuals", CourseId = 34, CreatedAt = DateTime.Now },
                new Module { Title = "Module 5 - Mastering Stage Presence", CourseId = 34, CreatedAt = DateTime.Now },
                new Module { Title = "Module 6 - Engaging Large Audiences", CourseId = 34, CreatedAt = DateTime.Now },
                new Module { Title = "Module 7 - Handling Q&A Sessions", CourseId = 34, CreatedAt = DateTime.Now },
                new Module { Title = "Module 8 - Using Technology Effectively", CourseId = 34, CreatedAt = DateTime.Now },
                new Module { Title = "Module 9 - Rehearsing Keynotes", CourseId = 34, CreatedAt = DateTime.Now },
                new Module { Title = "Module 10 - Delivering a Memorable Keynote", CourseId = 34, CreatedAt = DateTime.Now },

                // Course 35: Persuasive Pitching (Advanced, CourseId 35)
                new Module { Title = "Module 1 - Pitching Fundamentals", CourseId = 35, CreatedAt = DateTime.Now },
                new Module { Title = "Module 2 - Understanding Stakeholders", CourseId = 35, CreatedAt = DateTime.Now },
                new Module { Title = "Module 3 - Crafting a Winning Pitch", CourseId = 35, CreatedAt = DateTime.Now },
                new Module { Title = "Module 4 - Emotional and Logical Appeals", CourseId = 35, CreatedAt = DateTime.Now },
                new Module { Title = "Module 5 - Visuals for Pitches", CourseId = 35, CreatedAt = DateTime.Now },
                new Module { Title = "Module 6 - Delivery Techniques", CourseId = 35, CreatedAt = DateTime.Now },
                new Module { Title = "Module 7 - Handling Objections", CourseId = 35, CreatedAt = DateTime.Now },
                new Module { Title = "Module 8 - Pitch Practice Sessions", CourseId = 35, CreatedAt = DateTime.Now },
                new Module { Title = "Module 9 - Refining Your Pitch", CourseId = 35, CreatedAt = DateTime.Now },
                new Module { Title = "Module 10 - Closing the Pitch", CourseId = 35, CreatedAt = DateTime.Now },
                #endregion

                #region SkillId 5: Time Management (Courses 37-45)
                // Course 37: Time Management 101 (Beginner, CourseId 37)
                new Module { Title = "Module 1 - Time Management Basics", CourseId = 37, CreatedAt = DateTime.Now },
                new Module { Title = "Module 2 - Identifying Time Wasters", CourseId = 37, CreatedAt = DateTime.Now },
                new Module { Title = "Module 3 - Setting Priorities", CourseId = 37, CreatedAt = DateTime.Now },
                new Module { Title = "Module 4 - Creating To-Do Lists", CourseId = 37, CreatedAt = DateTime.Now },
                new Module { Title = "Module 5 - Using Planners", CourseId = 37, CreatedAt = DateTime.Now },
                new Module { Title = "Module 6 - Avoiding Procrastination", CourseId = 37, CreatedAt = DateTime.Now },
                new Module { Title = "Module 7 - Time Blocking Basics", CourseId = 37, CreatedAt = DateTime.Now },
                new Module { Title = "Module 8 - Managing Distractions", CourseId = 37, CreatedAt = DateTime.Now },
                new Module { Title = "Module 9 - Daily Planning", CourseId = 37, CreatedAt = DateTime.Now },
                new Module { Title = "Module 10 - Productivity Habits", CourseId = 37, CreatedAt = DateTime.Now },

                // Course 38: Prioritization Techniques (Beginner, CourseId 38)
                new Module { Title = "Module 1 - Prioritization Fundamentals", CourseId = 38, CreatedAt = DateTime.Now },
                new Module { Title = "Module 2 - Eisenhower Matrix", CourseId = 38, CreatedAt = DateTime.Now },
                new Module { Title = "Module 3 - ABC Prioritization", CourseId = 38, CreatedAt = DateTime.Now },
                new Module { Title = "Module 4 - Aligning with Goals", CourseId = 38, CreatedAt = DateTime.Now },
                new Module { Title = "Module 5 - Assessing Task Impact", CourseId = 38, CreatedAt = DateTime.Now },
                new Module { Title = "Module 6 - Handling Urgent Tasks", CourseId = 38, CreatedAt = DateTime.Now },
                new Module { Title = "Module 7 - Avoiding Overload", CourseId = 38, CreatedAt = DateTime.Now },
                new Module { Title = "Module 8 - Prioritization Tools", CourseId = 38, CreatedAt = DateTime.Now },
                new Module { Title = "Module 9 - Practice Prioritization", CourseId = 38, CreatedAt = DateTime.Now },
                new Module { Title = "Module 10 - Reviewing Priorities", CourseId = 38, CreatedAt = DateTime.Now },

                // Course 40: Advanced Task Management (Intermediate, CourseId 40)
                new Module { Title = "Module 1 - Task Management Overview", CourseId = 40, CreatedAt = DateTime.Now },
                new Module { Title = "Module 2 - Breaking Down Complex Tasks", CourseId = 40, CreatedAt = DateTime.Now },
                new Module { Title = "Module 3 - Creating Workflows", CourseId = 40, CreatedAt = DateTime.Now },
                new Module { Title = "Module 4 - Using Task Management Tools", CourseId = 40, CreatedAt = DateTime.Now },
                new Module { Title = "Module 5 - Setting Deadlines", CourseId = 40, CreatedAt = DateTime.Now },
                new Module { Title = "Module 6 - Tracking Progress", CourseId = 40, CreatedAt = DateTime.Now },
                new Module { Title = "Module 7 - Optimizing Task Sequences", CourseId = 40, CreatedAt = DateTime.Now },
                new Module { Title = "Module 8 - Handling Dependencies", CourseId = 40, CreatedAt = DateTime.Now },
                new Module { Title = "Module 9 - Task Management Practice", CourseId = 40, CreatedAt = DateTime.Now },
                new Module { Title = "Module 10 - Workflow Optimization", CourseId = 40, CreatedAt = DateTime.Now },

                // Course 41: Delegation Skills (Intermediate, CourseId 41)
                new Module { Title = "Module 1 - Delegation Fundamentals", CourseId = 41, CreatedAt = DateTime.Now },
                new Module { Title = "Module 2 - Identifying Delegable Tasks", CourseId = 41, CreatedAt = DateTime.Now },
                new Module { Title = "Module 3 - Choosing the Right Person", CourseId = 41, CreatedAt = DateTime.Now },
                new Module { Title = "Module 4 - Clear Communication", CourseId = 41, CreatedAt = DateTime.Now },
                new Module { Title = "Module 5 - Setting Expectations", CourseId = 41, CreatedAt = DateTime.Now },
                new Module { Title = "Module 6 - Monitoring Progress", CourseId = 41, CreatedAt = DateTime.Now },
                new Module { Title = "Module 7 - Providing Feedback", CourseId = 41, CreatedAt = DateTime.Now },
                new Module { Title = "Module 8 - Avoiding Micromanagement", CourseId = 41, CreatedAt = DateTime.Now },
                new Module { Title = "Module 9 - Delegation Practice", CourseId = 41, CreatedAt = DateTime.Now },
                new Module { Title = "Module 10 - Building Trust in Delegation", CourseId = 41, CreatedAt = DateTime.Now },

                // Course 43: Strategic Time Management (Advanced, CourseId 43)
                new Module { Title = "Module 1 - Strategic Time Management", CourseId = 43, CreatedAt = DateTime.Now },
                new Module { Title = "Module 2 - Aligning Time with Goals", CourseId = 43, CreatedAt = DateTime.Now },
                new Module { Title = "Module 3 - Long-Term Planning", CourseId = 43, CreatedAt = DateTime.Now },
                new Module { Title = "Module 4 - Prioritizing Strategic Tasks", CourseId = 43, CreatedAt = DateTime.Now },
                new Module { Title = "Module 5 - Optimizing Daily Schedules", CourseId = 43, CreatedAt = DateTime.Now },
                new Module { Title = "Module 6 - Leveraging Technology", CourseId = 43, CreatedAt = DateTime.Now },
                new Module { Title = "Module 7 - Balancing Multiple Roles", CourseId = 43, CreatedAt = DateTime.Now },
                new Module { Title = "Module 8 - Measuring Time Efficiency", CourseId = 43, CreatedAt = DateTime.Now },
                new Module { Title = "Module 9 - Strategic Delegation", CourseId = 43, CreatedAt = DateTime.Now },
                new Module { Title = "Module 10 - Time Management Scenarios", CourseId = 43, CreatedAt = DateTime.Now },

                // Course 44: Productivity Systems Design (Advanced, CourseId 44)
                new Module { Title = "Module 1 - Productivity Systems Overview", CourseId = 44, CreatedAt = DateTime.Now },
                new Module { Title = "Module 2 - Assessing Current Systems", CourseId = 44, CreatedAt = DateTime.Now },
                new Module { Title = "Module 3 - Designing Custom Workflows", CourseId = 44, CreatedAt = DateTime.Now },
                new Module { Title = "Module 4 - Integrating Tools", CourseId = 44, CreatedAt = DateTime.Now },
                new Module { Title = "Module 5 - Automating Repetitive Tasks", CourseId = 44, CreatedAt = DateTime.Now },
                new Module { Title = "Module 6 - Creating Feedback Loops", CourseId = 44, CreatedAt = DateTime.Now },
                new Module { Title = "Module 7 - Scaling Productivity Systems", CourseId = 44, CreatedAt = DateTime.Now },
                new Module { Title = "Module 8 - Adapting to Change", CourseId = 44, CreatedAt = DateTime.Now },
                new Module { Title = "Module 9 - System Optimization Practice", CourseId = 44, CreatedAt = DateTime.Now },
                new Module { Title = "Module 10 - Long-Term Productivity", CourseId = 44, CreatedAt = DateTime.Now }
                #endregion
            };

            return modules;
        }
    }
}