using Evolvify.Domain.Entities.User;
using Evolvify.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Infrastructure.Configurations.SubscriptionConfigurations
{
     public class SubscriptionPlanConfiguration: IEntityTypeConfiguration<SubscriptionPlan>
    {
       
            public void Configure(EntityTypeBuilder<SubscriptionPlan> builder)
            {

                var intervalConverter = new EnumToStringConverter<SubscriptionInterval>();
                builder.Property(p => p.Interval)
                    .HasConversion(intervalConverter);

                builder
               .Property(p => p.Price)
               .HasColumnType("decimal(18,2)");
            }
        }
    }

