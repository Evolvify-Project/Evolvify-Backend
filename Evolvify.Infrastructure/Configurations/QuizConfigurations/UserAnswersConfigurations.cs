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
    public class UserAnswersConfigurations : IEntityTypeConfiguration<UserAnswers>
    {
        public void Configure(EntityTypeBuilder<UserAnswers> builder)
        {
            builder.HasOne(UA => UA.Question)
                .WithMany()
                .HasForeignKey(UA => UA.QuestionId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(UA => UA.Answer)
                .WithMany()
                .HasForeignKey(UA => UA.AnswerId);

            builder.HasOne(UA=>UA.User)
                .WithMany()
                .HasForeignKey(UA => UA.UserId);
        }
    }
}
