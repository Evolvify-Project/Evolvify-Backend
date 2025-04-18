using Evolvify.Domain.Entities.Progress;
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
    public class ModuleProgressConfigurations : IEntityTypeConfiguration<ModuleProgress>
    {
       
        public void Configure(EntityTypeBuilder<ModuleProgress> builder)
        {
            builder.HasKey(mp => new { mp.ModuleId, mp.UserId });

            builder
                .HasOne(mp => mp.Module)
                .WithMany()
                .HasForeignKey(mp => mp.ModuleId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(mp => mp.User)
                .WithMany()
                .HasForeignKey(mp => mp.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            
        }

    }
}
