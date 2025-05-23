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
    public class QuizAttemptConfigurations : IEntityTypeConfiguration<QuizAttempt>
    {
        public void Configure(EntityTypeBuilder<QuizAttempt> builder)
        {
            builder.HasOne(QR => QR.Quiz)
                .WithMany()
                .HasForeignKey(QR => QR.QuizId);
            
            builder.HasOne(QR => QR.User)
                .WithMany()
                .HasForeignKey(QR => QR.UserId);

        }
    }
}
