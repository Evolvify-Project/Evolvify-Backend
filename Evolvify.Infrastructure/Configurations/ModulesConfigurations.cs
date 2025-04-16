using Evolvify.Domain.Entities;
using Evolvify.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Infrastructure.Configurations
{
    public class ModulesConfigurations : IEntityTypeConfiguration<Module>
    {
        public void Configure(EntityTypeBuilder<Module> builder)
        {
            builder.HasOne(M => M.Course)
                .WithMany(S => S.Modules)
                .HasForeignKey(M => M.CourseId);
        }
    }
}
