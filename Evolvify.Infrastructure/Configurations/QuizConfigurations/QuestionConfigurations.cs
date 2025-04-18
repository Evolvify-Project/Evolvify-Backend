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
    public class QuestionConfigurations : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.HasOne(Question => Question.Quiz)
                .WithMany(Quiz => Quiz.Questions)
                .HasForeignKey(Question => Question.QuizId);

        }
    }
}
