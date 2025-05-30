using Evolvify.Domain.Entities.User;
using Evolvify.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Infrastructure.Configurations.SubscriptionConfigurations
{
    public class SubscriptionConfiguration : IEntityTypeConfiguration<Subscription>
    {
        public void Configure(EntityTypeBuilder<Subscription> builder)
        {
            builder.HasOne<ApplicationUser>(s => s.User)
                .WithOne(u => u.Subscription)
                .HasForeignKey<Subscription>(s => s.UserId);

            var converter = new EnumToStringConverter<PlanType>();
            builder.Property(s => s.PlanType)
                .HasConversion(converter);

            var statusConverter = new EnumToStringConverter<SubscriptionStatus>();
            builder.Property(s => s.Status)
                .HasConversion(statusConverter);

            var intervalConverter = new EnumToStringConverter<SubscriptionInterval>();
            builder.Property(s => s.Interval)
                .HasConversion(intervalConverter);
                
            

        }


    }
    public class SubscriptionPlanConfiguration : IEntityTypeConfiguration<SubscriptionPlan>
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
