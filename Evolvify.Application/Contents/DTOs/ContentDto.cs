using Evolvify.Application.Modules.DTO;
using Evolvify.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Contents.DTOs
{
    public class ContentDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
        public string ContentType { get; set; }=string.Empty;
    }
}
