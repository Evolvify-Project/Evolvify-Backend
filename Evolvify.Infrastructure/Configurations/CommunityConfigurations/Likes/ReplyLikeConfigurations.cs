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
    public class ReplyLikeConfigurations : IEntityTypeConfiguration<ReplyLike>
    {
        public void Configure(EntityTypeBuilder<ReplyLike> builder)
        {
            builder.HasOne(rl=> rl.Reply)
                .WithMany(r => r.Likes)
                .HasForeignKey(rl => rl.ReplyId)
                .OnDelete(DeleteBehavior.Restrict)
                ;

            builder.HasOne(rl => rl.User)
                .WithMany()
                .HasForeignKey(rl => rl.UserId);

            builder.Property(cl => cl.Id)
                .HasDefaultValueSql("NEWID()");
        }
    }
}
