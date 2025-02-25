using Evolvify.Domain.Entities;
using Evolvify.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Infrastructure.Data.Seeding.Skills
{
    public class SkillSeeder
    {
        public static List<Skill> GetSkills()
        {
            var skillList = new List<Skill>
            {
                new Skill()
                {
                    Name = "Communication Skills",
                    Description = "The ability to clearly express ideas, actively listen, and engage in effective verbal and written communication.",

                    Modules = new List<Module>
                    {
                        new Module
                        {
                            Title = "Effective Communication",
                            Level = Level.Beginner,
                            Contents = new List<Content>
                            {
                                new Content
                                {
                                    Title = "Introduction to Communication",
                                    Url = "https://example.com/video1",
                                    Text = "Learn the basics of effective communication.",
                                    ContentType = ContentTypes.Video
                                },
                                new Content
                                {
                                    Title = "Active Listening Techniques",
                                    Url = "https://example.com/article1",
                                    Text = "How to improve your listening skills for better communication.",
                                    ContentType = ContentTypes.Article
                                }
                            }
                        }
                    }
                },
                new Skill
                {
                    Name="Interview Skills",
                    Description="Techniques and strategies for confidently handling job interviews, answering questions effectively, and presenting oneself professionally.",
                    
                    Modules = new List<Module>
                    {
                        new Module
                        {
                            Title = "Mastering Interview Skills",
                            Level = Level.Intermediate,
                            Contents = new List<Content>
                            {
                                new Content
                                {
                                    Title = "Common Interview Questions",
                                    Url = "https://example",
                                    Text = "Prepare for your next interview with these common questions.",
                                    ContentType = ContentTypes.Video
                                },
                                new Content
                                {
                                    Title = "Body Language in Interviews",
                                    Url = "https://example.com/pdf1",
                                    Text = "Learn the importance of body language during job interviews.",
                                    ContentType = ContentTypes.PDF
                                }

                            }
                        }
                    }
                },
                new Skill
                {
                    Name="Teamwork",
                    Description="The ability to collaborate with others, work efficiently in a team environment, and contribute to group success.",
                    Modules = new List<Module>
                    {
                        new Module
                        {
                            Title = "Building Team Collaboration",
                            Level = Level.Advanced,
                            Contents = new List<Content>
                            {
                                new Content
                                {
                                    Title = "The Art of Teamwork",
                                    Url = "https://example.com/video3",
                                    Text = "How to work effectively in a team environment.",
                                    ContentType = ContentTypes.Video
                                }
                            }
                        }
                    }

                    

                },
                new Skill
                {
                    Name="Presentation Skills",
                    Description="The capability to create and deliver engaging presentations with confidence, clarity, and impact."
                    , Modules = new List<Module>
                    {
                        new Module
                        {
                            Title = "Presentation Mastery",
                            Level = Level.Advanced,
                            Contents = new List<Content>
                            {
                                new Content
                                {
                                    Title = "Structuring a Winning Presentation",
                                    Url = "https://example.com/video4",
                                    Text = "Learn how to structure a presentation for maximum impact.",
                                    ContentType = ContentTypes.Video
                                }

                            }
                        }
                    }
                    

                },
                new Skill
                {
                    Name="Time Management",
                    Description="The skill of prioritizing tasks, managing deadlines, and optimizing productivity for efficient work completion."
                    , Modules = new List<Module>
                    {
                        new Module
                        {
                            Title = "Time Management Essentials",
                            Level = Level.Beginner,
                            Contents = new List<Content>
                            {
                                new Content
                                {
                                    Title = "Time Management Techniques",
                                    Url = "https://example.com/video5",
                                    Text = "Learn effective time management strategies.",
                                    ContentType = ContentTypes.Video
                                }
                            }
                        }
                    }


                }
            };

            return skillList;

        }
    }
}
