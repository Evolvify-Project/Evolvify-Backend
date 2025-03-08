using Evolvify.Domain.Entities.Community.Likes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Infrastructure.Configurations.CommunityConfigurations.Likes
{
    public class CommentLikeConfigurations : IEntityTypeConfiguration<CommentLike>
    {
        public void Configure(EntityTypeBuilder<CommentLike> builder)
        {
            builder.HasOne(cl => cl.Comment)
                .WithMany(c => c.Likes)
                .HasForeignKey(cl => cl.CommentId)
                .OnDelete(DeleteBehavior.Restrict)
                ;

            builder.HasOne(cl => cl.User)
                .WithMany()
                .HasForeignKey(cl => cl.UserId);
            
        }
    }
}
