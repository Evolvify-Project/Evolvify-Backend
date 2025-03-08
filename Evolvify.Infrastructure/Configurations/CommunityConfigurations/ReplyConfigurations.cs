using Evolvify.Domain.Entities.Community;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Infrastructure.Configurations.CommunityConfigurations
{
    public class ReplyConfigurations : IEntityTypeConfiguration<Reply>
    {
        public void Configure(EntityTypeBuilder<Reply> builder)
        {
            
            builder.HasOne(r => r.User)
                .WithMany()
                .HasForeignKey(r => r.UserId);

            builder.Property(r => r.Content)
                .HasMaxLength(1000)
                .IsRequired();

            builder.HasOne(r => r.Comment)
                .WithMany(c => c.Replies)
                .HasForeignKey(r => r.CommentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
