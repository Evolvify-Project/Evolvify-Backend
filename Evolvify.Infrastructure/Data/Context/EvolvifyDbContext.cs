using Evolvify.Domain.Entities;
using Evolvify.Domain.Entities.Assessment;
using Evolvify.Domain.Entities.Community;
using Evolvify.Domain.Entities.Community.Likes;
using Evolvify.Domain.Entities.Progress;
using Evolvify.Domain.Entities.Quiz;
using Evolvify.Domain.Entities.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Module = Evolvify.Domain.Entities.Module;

namespace Evolvify.Infrastructure.Data.Context
{
    public class EvolvifyDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        public EvolvifyDbContext(DbContextOptions<EvolvifyDbContext> options):base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);

           
        }


        public DbSet<Skill> Skills { get; set; }
        public DbSet<Course> Courses  { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CommentLike> CommentLikes { get; set; }
        public DbSet<PostLike> PostLikes { get; set; }
        public DbSet<Quiz> Quizs { get; set; } 
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<QuizResult> QuizResults { get; set; }
        public DbSet<UserAnswers> UserAnswers { get; set; }
        public DbSet<ModuleProgress> ModuleProgresses { get; set; }
        public DbSet<CourseProgress> CourseProgresses { get; set; }
        public DbSet<AssessmentResult> AssessmentResults { get; set; }
        public DbSet<SubscriptionPlan> SubscriptionPlans { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
       

    }
}
