using Evolvify.Domain.Entities.Quiz;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Infrastructure.Configurations.QuizConfigurations
{
    public class UserAnswerConfigurations : IEntityTypeConfiguration<UserAnswer>
    {
        public void Configure(EntityTypeBuilder<UserAnswer> builder)
        {
            builder.HasOne(UA => UA.Answer)
                .WithMany()
                .HasForeignKey(UA => UA.AnswerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(UA => UA.QuizAttempt)
                .WithMany(qa => qa.UserAnswers)
                .HasForeignKey(UA => UA.QuizAttemptId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
