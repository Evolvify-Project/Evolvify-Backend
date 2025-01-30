using Evolvify.Domain.Entities;
using Evolvify.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Infrastructure.Configurations
{
    public class ContentsConfigurations : IEntityTypeConfiguration<Content>
    {
        public void Configure(EntityTypeBuilder<Content> builder)
        {
            builder.Property(m => m.ContentType)
                .HasConversion(ContentType => ContentType.ToString(), ContentType => (ContentTypes)Enum.Parse(typeof(ContentTypes), ContentType));
        }
    }
}
