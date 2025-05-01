using Evolvify.Domain.Entities.Assessment;
using Evolvify.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Infrastructure.Configurations.AssessmentConfigurations
{
    public class AssessmentResultConfiguration : IEntityTypeConfiguration<AssessmentResult>
    {
        public void Configure(EntityTypeBuilder<AssessmentResult> builder)
        {
            builder.HasKey(ar=> new {ar.SkillId,ar.UserId });

            builder
                .HasOne(ar => ar.Skill)
                .WithMany()
                .HasForeignKey(ar => ar.SkillId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(ar => ar.User)
                .WithMany()
                .HasForeignKey(ar => ar.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            var converter = new EnumToStringConverter<Level>();
            builder.Property(ar => ar.Level)
                .HasConversion(converter);
        }
    }
}

