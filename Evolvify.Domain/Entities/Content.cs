using Evolvify.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Domain.Entities
{
    public class Content
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;

        public ContentTypes ContentType { get; set; }
        public ICollection<Module> Modules { get; set; }

    }
}
